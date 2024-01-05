
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
    // Constructor
    public PlayerGroundState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }



    #region Override

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_PlayerAnimationData.GroundHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_PlayerAnimationData.GroundHash);
    }

    protected override void AddInputActionCallbacks()
    {
        base.AddInputActionCallbacks();
        
    }

    protected override void RemoveInputActionCallbacks()
    {
        base.RemoveInputActionCallbacks();
        _playerInput.PlayerActions.MovementApply.started -= OnMovementPerformed;
        _playerInput.PlayerActions.Run.started -= OnRunStarted;
    }

    #endregion



    #region Events
    
    

    #endregion
}