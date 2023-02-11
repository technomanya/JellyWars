using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviourPlayer : BodyBaseBehavour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerJelly");
        foreach (var eye in eyes)
        {
            eye.interactCircle = GameManager.Instance.interactCircle.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.GetComponent<BodyBehaviourEnemy>())
        {
            //var enemy = GetComponent<BodyBehaviourEnemy>();
            
            col.GetComponent<BodyBehaviourEnemy>().PullToward(transform,enlargeLevel);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.collider.GetComponent<BodyBehaviourEnemy>()) return;
        var enemy = col.collider.GetComponent<BodyBehaviourEnemy>();
        if(enlargeLevel>=enemy.enlargeLevel)
            Destroy(enemy.gameObject);
        else
        {
            Destroy(gameObject);
        }
    }
}
