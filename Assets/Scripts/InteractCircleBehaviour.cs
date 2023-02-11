using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EffectType
{
    Multiply,
    Enlarge,
    Shoot,
    Default
}
public class InteractCircleBehaviour : MonoBehaviour
{
    public List<BodyBehaviourPlayer> bodyEffectList;
    public EffectType circleEffect = EffectType.Default;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.isTrigger &&col.GetComponent<BodyBehaviourPlayer>())
        {
            bodyEffectList.Add(col.GetComponent<BodyBehaviourPlayer>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.isTrigger &&other.GetComponent<BodyBehaviourPlayer>())
        {
            bodyEffectList.Remove(other.GetComponent<BodyBehaviourPlayer>());
        }
    }
}
