
public class LocomotionState : BaseFiniteState
{
    // Constructor
    public LocomotionState(PlayerController controller, Player player) : base(controller, player) { }

    public override void OnEnter()
    {
        _PlayerController.Animator.CrossFade(_Player.AnimationData.LocomotionHash, CROSS_FADE_DURATION);
    }

    public override void FixedUpdate()
    {
        _PlayerController.PlayerMovement.HandleMovement();
    }

    public override void OnExit()
    {
        _PlayerController.PlayerMovement.ResetMovement();
    }
}
