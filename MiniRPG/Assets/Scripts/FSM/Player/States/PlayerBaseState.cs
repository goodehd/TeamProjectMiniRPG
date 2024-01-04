
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerBaseState : IFiniteState
{
    #region Fields
    
    // Inverse Reference
    protected readonly PlayerStateMachine _playerStateMachine;
    protected readonly PlayerInput _playerInput;
    protected readonly NavMeshAgent _playerAgent;
    protected readonly Animator _playerAnimator;
    protected readonly PlayerAnimationData _PlayerAnimationData;
    
    // Input Member
    protected bool _isRightButton;
    
    #endregion
    
    



    #region Constructor

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;

        _playerInput = _playerStateMachine.Player.PlayerInput;
        _playerAgent = _playerStateMachine.Player.PlayerAgent;
        _playerAnimator = _playerStateMachine.Player.PlayerAnimator;
        _PlayerAnimationData = _playerStateMachine.Player.AnimationData;
    }

    #endregion
    
    
    public virtual void Enter()
    {
        AddInputActionCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionCallbacks();
    }

    public virtual void HandleInput()
    { 
        
    }

    public virtual void UpdateLogic()
    {
        MovementToRay();
    }

    public virtual void UpdatePhysics()
    {
        
    }



    #region Inputs

    protected virtual void AddInputActionCallbacks()
    {
        _playerInput.PlayerActions.MovementApply.performed += OnMovementPerformed;
        _playerInput.PlayerActions.Run.started += OnRunStarted;
    }

    protected virtual void RemoveInputActionCallbacks()
    {
        _playerInput.PlayerActions.MovementApply.performed -= OnMovementPerformed;
        _playerInput.PlayerActions.Run.started -= OnRunStarted;
    }

    #endregion



    #region Movement

    private void MovementToRay()
    {
        if (!_isRightButton) return;
        
        var mousePos = _playerInput.PlayerActions.MovementAxis.ReadValue<Vector2>();
        var ray = _playerStateMachine.Player.MainCamera.ScreenPointToRay(mousePos);
        var walkableLayerMask = LayerMask.GetMask(Literals.LAYER_MASK_WALKABLE);
        
        if (Physics.Raycast(ray, out var hit, 100f, walkableLayerMask))
        {
            Debug.Log(hit.point);
            // Movement
            Movement(hit.point);
        }
    }

    private void Movement(Vector3 location)
    {
        _playerAgent.SetDestination(location);
    }

    #endregion



    #region Animations

    protected void StartAnimation(int animationHash)
    {
        _playerAnimator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        _playerAnimator.SetBool(animationHash, false);
    }

    #endregion



    #region Events

    protected virtual void OnRunStarted(InputAction.CallbackContext context) { }
    protected virtual void OnMovementPerformed(InputAction.CallbackContext context) { }

    #endregion
    
}
