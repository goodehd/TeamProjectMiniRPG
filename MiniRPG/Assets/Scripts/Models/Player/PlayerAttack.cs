using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //private readonly PlayerController _playerController;
    //private readonly PlayerInput _playerInput;
    private Animator _playerAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    public void Attack()
    {
        _playerAnimator.SetTrigger("IsAttack2");
    }

    public void Skill()
    {
        _playerAnimator.SetTrigger("IsAttack4");
    }

    //두번째 => 공격했을때 

}
