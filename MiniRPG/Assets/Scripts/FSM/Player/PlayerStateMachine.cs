
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Player Setup

    public Player Player { get; }
    
    // Inputs
    public Vector2 MovementInput { get; set; }
    
    public float MovementSpeed { get; private set; }

    #endregion
    
    

    #region States

    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }

    #endregion



    #region Constructor

    public PlayerStateMachine(Player player)
    {
        Player = player;
        InitializeState();
        InitializeInfo();

    }

    #endregion



    #region Initialize

    private void InitializeState()
    {
        IdleState = new PlayerIdleState(this);
        // WalkState = new PlayerWalkState(this);
        // RunState = new PlayerRunState(this);
    }
    
    private void InitializeInfo()
    {
        MovementSpeed = Player.PlayerData.MoveSpd.Value;
    }

    #endregion
}
