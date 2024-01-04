
using UnityEngine;

public class PlayerBaseState : IFiniteState
{
    #region Inverse Reference

    protected PlayerStateMachine _playerStateMachine;
    protected PlayerInput _playerInput;
    
    #endregion



    #region Constructor

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;

        _playerInput = _playerStateMachine.Player.PlayerInput;
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
        ReadMovementInput();
    }

    public virtual void UpdateLogic()
    {
        throw new System.NotImplementedException();
    }

    public virtual void UpdatePhysics()
    {
        throw new System.NotImplementedException();
    }



    #region Inputs

    protected virtual void AddInputActionCallbacks()
    {
        
    }

    protected virtual void RemoveInputActionCallbacks()
    {
        
    }

    private void ReadMovementInput()
    {
        _playerStateMachine.MovementInput = _playerInput.PlayerActions.MovementAxis.ReadValue<Vector2>();
        if(_playerInput.PlayerActions.MovementApply.performed)
    }

    private void Movement()
    {
        
    }

    #endregion



    #region Movements



    #endregion
}
