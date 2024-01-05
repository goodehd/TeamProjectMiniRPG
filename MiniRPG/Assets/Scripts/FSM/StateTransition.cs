
public class StateTransition : IStateTransition
{
    #region Fields

    // Properties (Interface)
    public IFiniteState To { get; }
    public IStatePredicate Condition { get; }
    
    #endregion
    
    
    // Constructor
    public StateTransition(IFiniteState to, IStatePredicate condition)
    {
        To = to;
        Condition = condition;
    }
}
