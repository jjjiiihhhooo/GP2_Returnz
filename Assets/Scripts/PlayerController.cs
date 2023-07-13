using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float damage;
    public float attackDelay;
    public float currentAttackDelay;
    public float moveSpeed;
    public Vector3 direction = Vector3.zero;

    public Animator anim;

    public GameState<PlayerController> currentState;
    public Enemy currentEnemy;

    public PlayerMoveState playerMoveState;
    public PlayerBattleState playerBattleState;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Init();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        currentState.StateUpdate(this);
        StateChoice();
        AttackDelay();
    }

    private void Init()
    {
        playerMoveState = new PlayerMoveState();
        playerBattleState = new PlayerBattleState();
        currentState = playerMoveState;
    }

    public void SetState(GameState<PlayerController> newState)
    {
        newState.StateChange(this);
    }

    public void StateChoice()
    {
        if(Vector3.Distance(this.transform.position, currentEnemy.transform.position) <= 1f)
        {
            if (currentState.GetType() != typeof(PlayerBattleState)) SetState(playerBattleState);
        }
        else
        {
            if (currentState.GetType() != typeof(PlayerMoveState)) SetState(playerMoveState);
        }
    }

    public void AttackDelay()
    {
        if (currentAttackDelay >= 0) currentAttackDelay -= Time.deltaTime;
    }
    
    public void GetEnemy(Enemy enemy)
    {
        currentEnemy = enemy;
    }

    public void Attack()
    {
        

        if (currentAttackDelay <= 0)
        {
            anim.SetTrigger("Attack");
            currentAttackDelay = attackDelay;
        }
    }

    public void Move()
    {
        direction = currentEnemy.transform.position - this.transform.position;

        transform.position += direction * 2 * Time.deltaTime;
    }
}
