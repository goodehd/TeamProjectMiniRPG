
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack
{
    #region Member Variables

    private float _attackCooldown = 0.5f;
    private float _attackDistance = 1f;

    private Vector3 _attackDirection;
    
    // input
    private Vector2 _screenPosition;

    private readonly PlayerController _playerController;
    private readonly PlayerInput _playerInput;

    #endregion



    #region Constructor

    public PlayerAttack(PlayerController playerController)
    {
        _playerController = playerController;
        _playerInput = _playerController.Input;
    }

    #endregion



    #region Attack Method

    public void HandleAttack()
    {
        AttackProcess();
    }

    public void HandleAttackRotation()
    {
        RotateTowardsAttackDirection();
    }

    public void AllocAttackInputEvent()
    {
        _playerInput.OnAttack += InputEventScreenPosition;
    }

    public void ReleaseAttackInputEvent()
    {
        _playerInput.OnAttack -= InputEventScreenPosition;
    }

    public void ResetAttack()
    {
        _attackDirection = Vector3.zero;
    }

    #endregion



    #region Main Process

    private void AttackProcess()
    {
        var playerTransform = _playerController.transform;
        var attackPos = playerTransform.position + _attackDirection * _attackDistance; // 공격 방향을 기준으로 위치 계산
        var hitEnemies = Physics.OverlapSphere(attackPos, _attackDistance);

        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Debug.Log("YES");
            }
        }
    }

    #endregion
    
    
    
    #region Helper Methods

    private void RotateTowardsAttackDirection()
    {
        if (_attackDirection == Vector3.zero) return;

        var currentDirection = _playerController.transform.forward;
        var newDirection = Vector3.RotateTowards(
            currentDirection, _attackDirection, 15 * Time.fixedDeltaTime, 0f);
        newDirection.y = 0f;

        _playerController.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    #endregion
    
    

    #region Events

    private void InputEventScreenPosition(Vector2 screenPosition)
    {
        _screenPosition = screenPosition;

        var mainCamera = _playerController.MainCamera;
        var ray = mainCamera.ScreenPointToRay(_screenPosition);
        RaycastHit hit;

        // 가상의 지면 평면에서 레이가 충돌하는 지점을 찾습니다.
        // 카메라의 높이(Y축)와 평면의 높이(예: y = 0)를 고려하여 계산합니다.
        const float planeY = 0f; // 가정: 게임 세계의 수평 평면은 y = 0에 위치
        var distance = (planeY - mainCamera.transform.position.y) / ray.direction.y;
        var worldPosition = mainCamera.transform.position + ray.direction * distance;

        var direction = new Vector3(worldPosition.x - _playerController.transform.position.x, 0, worldPosition.z - _playerController.transform.position.z);
        _attackDirection = direction.normalized;
        // var ray = mainCamera.ScreenPointToRay(_screenPosition);
        //
        // if (!Physics.Raycast(ray, out var hit, 100f)) return;
        //
        // var worldPosition = hit.point;
        // var direction = worldPosition - _playerController.transform.position;
        // _attackDirection = direction.normalized;
    }

    #endregion
}


public class PlayerAttack : MonoBehaviour
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

    /*private void OnCollisionEnter(Collision other)
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
    }*/
}
