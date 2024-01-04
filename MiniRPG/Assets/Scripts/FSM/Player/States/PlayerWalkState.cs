
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundState
{
    // Constructor
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }



    #region Override

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_PlayerAnimationData.WalkHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_PlayerAnimationData.WalkHash);
    }

    #endregion
}
