
using System.Collections.Generic;

public class FiniteStateNode
{
    #region Fields

    // Properties
    public IFiniteState State { get; }
    
    public HashSet<IStateTransition> Transitions { get; }

    #endregion
    
    
    
    // Constructor
    public FiniteStateNode(IFiniteState state)
    {
        State = state;
        Transitions = new HashSet<IStateTransition>();
    }



    #region Helper Methods

    public void AddTransition(IFiniteState to, IStatePredicate condition)
    {
        Transitions.Add(new StateTransition(to, condition));
    }

    #endregion
}
