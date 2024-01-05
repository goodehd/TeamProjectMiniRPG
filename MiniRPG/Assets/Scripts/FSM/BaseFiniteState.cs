
using UnityEngine;

public abstract class BaseFiniteState : IFiniteState
{
    #region Fields

    protected readonly PlayerController _PlayerController;
    protected readonly Player _Player;

    protected const float CROSS_FADE_DURATION = 0.02f;

    #endregion



    // Constructor
    protected BaseFiniteState(PlayerController controller, Player player)
    {
        _PlayerController = controller;
        _Player = player;
    }
    
    
    public virtual void OnEnter()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void OnExit()
    {
        
    }
}