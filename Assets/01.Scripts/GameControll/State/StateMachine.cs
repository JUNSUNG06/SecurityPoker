using System;
using System.Collections.Generic;

public class StateMachine<T>
{
    private T stateMachineClass;
    private Dictionary<Type, State<T>> stateList = new Dictionary<Type, State<T>>();

    private State<T> nowState;
    public State<T> NowState;

    private float stateDurationTime = 0f;
    public float StateDurationTime => stateDurationTime;

    public StateMachine(T _stateMachineClass, State<T> initState)
    {
        stateMachineClass = _stateMachineClass;
        AddState(initState);
        nowState = initState;
        nowState.OnStart();
    }

    public void AddState(State<T> state)
    {
        state.SetMachineWithClass(this, this.stateMachineClass);
        state.OnAwake();
        stateList.Add(state.GetType(), state);
    }

    public void ChangeState<Q>() where Q : State<T>
    {
        Type newState = typeof(Q);

        if(nowState.GetType() == newState)
        {
            return;
        }

        if(nowState != null)
        {
            nowState.OnEnd();
        }

        nowState = stateList[newState];
        nowState.OnStart();
        stateDurationTime = 0f;
    }

    public void Updata(float deltaTime)
    {
        nowState.OnUpdate(stateDurationTime);
        stateDurationTime += deltaTime;
    }
}
