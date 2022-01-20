using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    private Animator _animator; //캐릭터 자기자신 애니메이터

    private const string _moveSpeed = "moveSpeed";
    private const string _run = "Run";
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void WalkFunc(float _animSpeed)
    {
        _animator.SetFloat(_moveSpeed, _animSpeed);
    }

    public void RunFunc(bool _animBool)
    {
        _animator.SetBool(_run, _animBool);
    }
}
