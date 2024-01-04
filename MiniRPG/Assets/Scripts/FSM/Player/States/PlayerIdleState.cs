
public class PlayerIdleState : PlayerGroundState
{
    // Constructor
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }



    #region Override

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_PlayerAnimationData.IdleHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_PlayerAnimationData.IdleHash);
    }

    #endregion
}
