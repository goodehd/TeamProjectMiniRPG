
using UnityEngine;

public class PlayerIdleState : BaseFiniteState
{
    // Constructor
    public PlayerIdleState(PlayerController controller, Player player) : base(controller, player) { }

    public override void OnEnter()
    {
        _PlayerController.Animator.CrossFade(_Player.AnimationData.IdleHash, CROSS_FADE_DURATION);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
