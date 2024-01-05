
public interface IFiniteState
{
    void Enter();
    void Exit();
    
    void HandleInput();

    void UpdateLogic();
    void UpdatePhysics();
}