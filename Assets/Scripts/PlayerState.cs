using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : GameState<PlayerController>
{
    public override void StateChange(PlayerController Controller)
    {
        Controller.currentState.StateExit(Controller);
        Controller.currentState = this;
        StateEnter(Controller);
    }

    public override void StateEnter(PlayerController Controller)
    {
        Debug.Log("MoveStateEnter");
    }

    public override void StateUpdate(PlayerController Controller)
    {
        Controller.Move();
    }

    public override void StateExit(PlayerController Controller)
    {
        Debug.Log("MoveStateExit");
    }

}

public class PlayerBattleState : GameState<PlayerController>
{
    public override void StateChange(PlayerController Controller)
    {
        Controller.currentState.StateExit(Controller);
        Controller.currentState = this;
        StateEnter(Controller);
    }

    public override void StateEnter(PlayerController Controller)
    {
        Debug.Log("BattleStateEnter");
    }

    public override void StateUpdate(PlayerController Controller)
    {
        Controller.Attack();
    }

    public override void StateExit(PlayerController Controller)
    {
        Debug.Log("BattleStateExit");
    }
}
