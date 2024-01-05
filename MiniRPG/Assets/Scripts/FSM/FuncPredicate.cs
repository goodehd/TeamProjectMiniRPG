
using System;

public class FuncPredicate : IStatePredicate
{
    // Member
    private readonly Func<bool> _Func;
    
    // Constructor
    public FuncPredicate(Func<bool> func)
    {
        _Func = func;
    }
    
    // Interface Implement Method
    public bool Evaluate() => _Func.Invoke();
}
