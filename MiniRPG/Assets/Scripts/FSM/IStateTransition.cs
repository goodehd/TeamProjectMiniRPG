
public interface IStateTransition
{
    IFiniteState To { get; }
    IStatePredicate Condition { get; }
}