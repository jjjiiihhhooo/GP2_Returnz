using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Interface
{
    void Enter();
    void Exit();
}

interface IState<T>
{
    public void StateChange(T Controller);

    public void StateEnter(T Controller);

    public void StateUpdate(T Controller);

    public void StateExit(T Controller);
}
