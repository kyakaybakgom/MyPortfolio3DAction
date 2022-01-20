using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveManager : MonoBehaviour
{
    private MyPortfolio_3DAction _playerMoveActions; //입력키 action
    private Rigidbody _rigidbody; //캐릭터 rigdbody
    private PlayerAnimatorManager _playerAnimatorManager; //애니메이터 매니저

    private Vector3 _moveInput; //input 좌표
    private Vector3 _viewVec; //바라보는 곳

    private Transform _transform; //캐릭터 transfrom 자기자신

    private readonly float interpolation = 10f; //그래프 배율

    private float _moveSpeed; //캐릭터 스피드
    private readonly float _defaultSpeed = 1.0f;

    private void Awake()
    {
        //입력 actions 초기화
        _playerMoveActions = new MyPortfolio_3DAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        //초기화
        _transform = this.transform;

        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimatorManager = GetComponent<PlayerAnimatorManager>();

        _moveInput = Vector3.zero;

        _moveSpeed = _defaultSpeed; //스피드 초기화

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
    
    //키 입력 받아오기
    bool InputKeyValueFunc()
    {
        _moveInput.x = Mathf.Lerp(_moveInput.x, _playerMoveActions.Player.Move.ReadValue<Vector2>().x, Time.deltaTime * interpolation);
        _moveInput.z = Mathf.Lerp(_moveInput.z, _playerMoveActions.Player.Move.ReadValue<Vector2>().y, Time.deltaTime * interpolation);
        
        return true;
    }

    //키 입력 받아서 캐릭터 움직이기
    IEnumerator PlayerMovementFunc()
    {
        //입력대기
        yield return new WaitUntil(InputKeyValueFunc);

        //캐릭터 정면보기
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

        //캐릭터 이동
        _rigidbody.MovePosition(_rigidbody.position + _moveInput * Time.deltaTime * _moveSpeed);

        //animator
        _playerAnimatorManager.WalkFunc(_moveInput.magnitude);
        
        //재시작
        StartCoroutine("PlayerMovementFunc");
    }
}
