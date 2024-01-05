
public abstract class StateMachine
{
    #region Fields

    protected IFiniteState _currentState;

    #endregion

    

    #region State Methods

    public void TransitionState(IFiniteState newState)
    {
        _currentState?.Exit();

        _currentState = newState;
        
        _currentState?.Enter();
    }

    public void HandleInput()
    {
        _currentState?.HandleInput();
    }

    public void UpdateLogic()
    {
        _currentState?.UpdateLogic();
    }

    public void UpdatePhysics()
    {
        _currentState?.UpdatePhysics();
    }

    #endregion
}
