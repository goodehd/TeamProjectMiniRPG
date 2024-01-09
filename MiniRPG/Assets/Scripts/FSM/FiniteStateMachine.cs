
using System;
using System.Collections.Generic;
using System.Linq;

public class FiniteStateMachine
{
    #region Fields

    private FiniteStateNode _currentNode;
    private Dictionary<Type, FiniteStateNode> _nodes = new();
    private HashSet<IStateTransition> _anyTransitions = new();

    #endregion



    #region States Methods

    public void SetState(IFiniteState state)
    {
        _currentNode = _nodes[state.GetType()];
        _currentNode.State?.OnEnter();
    }

    private void ChangeState(IFiniteState state)
    {
        if (state == _currentNode.State) return;

        var previousState = _currentNode.State;
        var nextState = _nodes[state.GetType()].State;
        
        previousState?.OnExit();
        nextState?.OnEnter();

        _currentNode = _nodes[state.GetType()];
    }

    #endregion



    #region Transitions

    public void AddTransition(IFiniteState from, IFiniteState to, IStatePredicate condition)
    {
        GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
    }

    public void AddAnyTransition(IFiniteState to, IStatePredicate condition)
    {
        _anyTransitions.Add(new StateTransition(GetOrAddNode(to).State, condition));
    }

    private IStateTransition GetTransition()
    {
        foreach (var transition in _anyTransitions.
                     Where(transition => transition.Condition.Evaluate()))
        {
            return transition;
        }

        foreach (var transition in _currentNode.Transitions.
                     Where(transition => transition.Condition.Evaluate()))
        {
            return transition;
        }

        return null;
    }
    
    // Helper (Utility)
    FiniteStateNode GetOrAddNode(IFiniteState state)
    {
        var node = _nodes.GetValueOrDefault(state.GetType());

        if (node == null)
        {
            node = new FiniteStateNode(state);
            _nodes.Add(state.GetType(), node);
        }

        return node;
    }

    #endregion



    #region Updates

    public void Update()
    {
        var transition = GetTransition();
        if (transition != null)
            ChangeState(transition.To);
        
        _currentNode.State?.Update();
    }

    public void FixedUpdate()
    {
        _currentNode.State?.FixedUpdate();
    }

    #endregion
}
