using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveManager : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private MyPortfolio_3DAction _playerMoveActions;
    private Rigidbody _rigidbody;
    private Vector3 _moveInput;

    private void Awake()
    {
        _playerMoveActions = new MyPortfolio_3DAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _playerMoveActions.Enable();
    }

    private void OnDisable()
    {
        _playerMoveActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_playerMoveActions.Player.Move.ReadValue<Vector2>());
    }

    public void MovementKeyFunc(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ToString());
    }

    //Ű �Է� �޾ƿ���
    bool InputKeyValueFunc()
    {
        

        return true;
    }

    //Ű �Է� �޾Ƽ� ĳ���� �����̱�
    //IEnumerator PlayerMovementFunc()
    //{
    //    yield return new WaitUntil(InputKeyValueFunc());
    //}
}
