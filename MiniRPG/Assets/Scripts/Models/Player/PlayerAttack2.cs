/*
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    //private readonly PlayerController _playerController;
    //private readonly PlayerInput _playerInput;
    private Animator _playerAnimator;
    public bool isAttacking;

    void Start()
    {
        isAttacking = false;
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Skill();
        }

    }
    private void Attack()
    {
        isAttacking = true;
        _playerAnimator.SetTrigger("IsAttack2");

        //raycastAttack();

        Invoke("ResetAttack", 0.5f);
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }

    private void Skill()
    {
        _playerAnimator.SetTrigger("IsAttack4");
    }

    *//*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && isAttacking)
        {
            MonsterController monsterController = other.gameObject.GetComponent<MonsterController>();
            if (monsterController != null)
            {
                monsterController.MonsterAttacked(10);
            }
        }
    }*/

    /*private void raycastAttack()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 3f);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                // Enemy를 찾았을 때 처리 (예: 피 깎기)
                MonsterController monsterController = hit.collider.gameObject.GetComponent<MonsterController>();
                if (monsterController != null)
                {
                    // 데미지를 인자로 전달하여 MonsterAttacked 함수 호출
                    monsterController.MonsterAttacked(10);
                }
            }
        }
    }*//*
}*/