using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float currentHp;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float damage;
    [SerializeField] protected Animator anim;

    protected Transform camTransform;

    public float CurrentHp { get => currentHp; }
    public float Damage { get => damage; }

    
    protected virtual void Awake()
    {
        Init();
    }

    protected virtual void Update()
    {
        CanvasMove();
    }

    protected virtual void OnDisable()
    {

    }

    protected virtual void Init()
    {
        camTransform = Camera.main.transform;
        currentHp = maxHp;
    }

    protected virtual void CanvasMove()
    {
        transform.LookAt(transform.position + camTransform.rotation * Vector3.forward, camTransform.rotation * Vector3.up);
    }

    public virtual void Attack()
    {
        
    }

    public virtual void Hit(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0) Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
