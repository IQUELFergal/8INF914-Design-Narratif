public class StateMachine<T> where T : IState
{
    T currentState;
    T lastState;

    public T CurrentState { get => currentState; }
    public T LastState { get => lastState; }

    public StateMachine()
    {

    }
    public virtual void Initialize(T startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public virtual void ChangeState(T newState)
    {
        currentState.Exit();
        lastState = currentState;
        currentState = newState;
        currentState.Enter();
    }
}