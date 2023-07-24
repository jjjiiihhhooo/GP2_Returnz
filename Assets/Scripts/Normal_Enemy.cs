using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Enemy : Enemy
{
    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Init()
    {
        camTransform = Camera.main.transform;
    }

    protected override void CanvasMove()
    {
        base.CanvasMove();
    }

    public override void Attack()
    {

    }
}
