using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private float damage;
    [SerializeField] private float attackDelay;
    [SerializeField] private float currentAttackDelay;
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Transform playerCharacter;
    private string animName;
    public Vector3 direction;

    public Animator anim;
    private Transform camTransform;

    public GameState<PlayerController> currentState;

    public Enemy currentEnemy;

    private PlayerMoveState playerMoveState;
    private PlayerBattleState playerBattleState;

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
        CanvasMove();
    }

    private void CanvasMove()
    {
        playerCharacter.LookAt(transform.position + camTransform.rotation * Vector3.forward, camTransform.rotation * Vector3.up);
    }

    private void Init()
    {
        camTransform = Camera.main.transform;

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
        if(Physics.Raycast(transform.position, Vector3.forward, 1f, layer))
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
            anim.SetBool("isMove", false);
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("isBattle")) anim.SetBool("isBattle", true);
            currentAttackDelay = attackDelay;
        }
    }

    public void Move()
    {
        Debug.Log("Move!");
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("isBattle")) anim.SetBool("isBattle", false);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("isMove")) anim.SetBool("isMove", true);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
