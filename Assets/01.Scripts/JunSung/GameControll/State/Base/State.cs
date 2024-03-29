public abstract class State<T>
{
    public StateMachine<T> stateMachine;
    public T stateMachineClass;

    public void SetMachineWithClass(StateMachine<T> _stateMachine, T _stateMachineClass)
    {
        this.stateMachine = _stateMachine;
        this.stateMachineClass = _stateMachineClass;

        OnAwake();
    }

    public abstract void OnAwake();
    public abstract void OnStart();
    public abstract void OnUpdate(float deltaTime);
    public abstract void OnEnd();
    public abstract void OnTextMove();
}
