using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviourEnemy : BodyBaseBehavour
{
    public float magneticFoce;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("EnemyJelly");
    }

    public void PullToward(Transform pullCenter,int enlargeLevel)
    {
        var distance = Vector3.Distance(pullCenter.position, transform.position);
        var direction = pullCenter.position - transform.position;
        rb.AddForce(direction*magneticFoce*enlargeLevel/distance);
    }
}
