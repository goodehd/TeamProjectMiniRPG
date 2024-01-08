
public class AttackState : BaseFiniteState
{
    public AttackState(PlayerController controller, Player player) : base(controller, player) { }

    public override void OnEnter()
    {
        _PlayerController.Animator.CrossFade(_Player.AnimationData.Attack01Hash, CROSS_FADE_DURATION);
        _PlayerController.PlayerAttack.HandleAttack();
    }

    public override void FixedUpdate()
    {
        _PlayerController.PlayerAttack.HandleAttackRotation();
        //_PlayerController.PlayerMovement.HandleMovement();
    }

    public override void OnExit()
    {
        _PlayerController.PlayerAttack.ResetAttack();
    }
}