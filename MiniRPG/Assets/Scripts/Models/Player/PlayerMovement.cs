
using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement
{
    #region Member Variables

    // InGame Movement Speed = Base or State(Run, Walk)
    private float _movementSpeed;
    private float _currentSpeed;
    private float _velocity;
    
    private Vector2 _screenPosition;

    private Animator _playerAnimator;

    // Nav Mesh
    private NavMeshPath _path;
    private int _currentPathIndex;

    private readonly PlayerController _playerController;
    private readonly PlayerInput _playerInput;
    private readonly CharacterController _characterController;
    
    
    
    /* Properties */
    public float SmoothTime => 0.2f;
    
    public float CurrentSpeed
    {
        get => _currentSpeed;
        set => _currentSpeed = value;
    }
    
    public float Velocity
    {
        get => _velocity;
        set => _velocity = value;
    }

    #endregion



    #region Constructor

    public PlayerMovement(PlayerController playerController)
    {
        _playerController = playerController;
        _playerInput = _playerController.Input;
        _characterController = _playerController.Controller;
        _playerAnimator = playerController.Animator;

        _movementSpeed = _playerController.Player.PlayerData.MoveSpd.Value;
    }

    #endregion
    
    
    
    #region Movement Methods (public)

    public void AddMovementSpeed(float moveSpeed) => _movementSpeed += moveSpeed;

    public void SetMovementSpeed(float moveSpeed) => _movementSpeed = moveSpeed;
    
    public void HandleMovement()
    {
        MovementProcess();
        RotationProcess();
    }

    public void AllocMovementInputEvent()
    {
        _playerInput.OnMovement += InputEventScreenPosition;
    }

    public void ReleaseMovementInputEvent()
    {
        _playerInput.OnMovement -= InputEventScreenPosition;
    }

    #endregion



    #region Main

    private void MovementProcess()
    {
        if (_path == null || _currentPathIndex >= _path.corners.Length)
            return;

        var targetPosition = _path.corners[_currentPathIndex];
        var direction = (targetPosition - _playerController.transform.position).normalized;

        _characterController.Move(direction * (_movementSpeed * Time.fixedDeltaTime));
        
        if (!(Vector3.Distance(_playerController.transform.position, targetPosition) < 0.1f)) return;
        
        _currentPathIndex++;
        if (_currentPathIndex >= _path.corners.Length)
        {
            _path = null; // 경로 완료
            _playerAnimator.SetBool("IsWalking", false); // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        }
        
    }
    
    public void RotationProcess()
    {
        if (_path == null || _currentPathIndex >= _path.corners.Length)
            return;

        var targetPosition = _path.corners[_currentPathIndex];
        var direction = (targetPosition - _playerController.transform.position).normalized;

        RotateCharacter(direction);
    }

    private void RotateCharacter(Vector3 direction)
    {
        if (direction.magnitude < float.Epsilon) return;

        var currentDirection = _playerController.transform.forward;
        var newDirection = Vector3.RotateTowards(
            currentDirection, direction, 15f * Time.fixedDeltaTime, 0f);
        newDirection.y = 0f;
        _playerController.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    // private void HandleMovementHorizontal(Vector3 direction)
    // {
    //     var velocity = direction * (_movementSpeed * Time.fixedDeltaTime);
    //
    //     _playerRBody.velocity = new Vector3(velocity.x, _playerRBody.velocity.y, velocity.z);
    // }
    //
    // private void HandleRotation(Vector3 direction)
    // {
    //     var targetRotation = Quaternion.LookRotation(direction);
    //     var playerRotation = _playerController.transform.rotation;
    //     _playerController.transform.rotation = Quaternion.RotateTowards(
    //         playerRotation, targetRotation, 8f * Time.fixedDeltaTime);
    // }

    /*private void Attack()
    {
        _playerAnimator.SetTrigger("IsAttack2");
    }

    private void Skill()
    {
        _playerAnimator.SetTrigger("IsAttack4");
    }*/

    #endregion



    #region Helper

    // public float SmoothSpeed(float magnitude)
    // {
    //     return Mathf.SmoothDamp(CurrentSpeed, magnitude, ref Velocity, SmoothTime)
    // }

    #endregion



    #region Events

    private void InputEventScreenPosition(Vector2 screenPosition)
    {
        _playerAnimator.SetBool("IsWalking", true); // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        _screenPosition = screenPosition;
        
        var ray = _playerController.MainCamera.ScreenPointToRay(_screenPosition);

        if (!Physics.Raycast(ray, out var hit, 100f)) return;
        
        _path = new NavMeshPath();
        if (NavMesh.CalculatePath(_playerController.transform.position, hit.point, NavMesh.AllAreas, _path))
        {
            _currentPathIndex = 0;
        }
    }
    
    #endregion
}
