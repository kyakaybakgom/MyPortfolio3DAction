using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveManager : MonoBehaviour
{
    private MyPortfolio_3DAction _playerMoveActions; //�Է�Ű action
    private Rigidbody _rigidbody; //ĳ���� rigdbody
    private PlayerAnimatorManager _playerAnimatorManager; //�ִϸ����� �Ŵ���

    private Vector3 _moveInput; //input ��ǥ
    private Vector3 _viewVec; //�ٶ󺸴� ��

    private Transform _transform; //ĳ���� transfrom �ڱ��ڽ�

    private readonly float interpolation = 10f; //�׷��� ����

    private float _moveSpeed; //ĳ���� ���ǵ�
    private readonly float _defaultSpeed = 1.0f;

    private void Awake()
    {
        //�Է� actions �ʱ�ȭ
        _playerMoveActions = new MyPortfolio_3DAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        //�ʱ�ȭ
        _transform = this.transform;

        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimatorManager = GetComponent<PlayerAnimatorManager>();

        _moveInput = Vector3.zero;

        _moveSpeed = _defaultSpeed; //���ǵ� �ʱ�ȭ

        StartCoroutine("PlayerMovementFunc");
    }

    private void OnEnable()
    {
        _playerMoveActions.Enable();
    }

    private void OnDisable()
    {
        _playerMoveActions.Disable();
        StopCoroutine("PlayerMovementFunc");
    }
    
    //Ű �Է� �޾ƿ���
    bool InputKeyValueFunc()
    {
        _moveInput.x = Mathf.Lerp(_moveInput.x, _playerMoveActions.Player.Move.ReadValue<Vector2>().x, Time.deltaTime * interpolation);
        _moveInput.z = Mathf.Lerp(_moveInput.z, _playerMoveActions.Player.Move.ReadValue<Vector2>().y, Time.deltaTime * interpolation);
        
        return true;
    }

    //Ű �Է� �޾Ƽ� ĳ���� �����̱�
    IEnumerator PlayerMovementFunc()
    {
        //�Է´��
        yield return new WaitUntil(InputKeyValueFunc);

        //ĳ���� ���麸��
        if(_moveInput == Vector3.zero)
        {
            try
            {
                transform.forward = _viewVec;
            }
            catch { }
        }
        else
        {
            transform.forward = _moveInput;
            _viewVec = _moveInput;
        }

        //ĳ���� �̵�
        _rigidbody.MovePosition(_rigidbody.position + _moveInput * Time.deltaTime * _moveSpeed);

        //animator
        _playerAnimatorManager.WalkFunc(_moveInput.magnitude);
        
        //�����
        StartCoroutine("PlayerMovementFunc");
    }
}
