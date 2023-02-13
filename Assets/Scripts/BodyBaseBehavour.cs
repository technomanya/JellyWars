using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BodyBaseBehavour : MonoBehaviour
{
    private int maxEnlargeLevel;
    
    public Rigidbody2D rb;
    public EyeMovements[] eyes;
    public int enlargeLevel;
    public ParticleSystem appearEffect;
    public ParticleSystem jumpEffect;
    public ParticleSystem disappearEffect;
    
    [SerializeField]private float currMoveForce;
    private bool isInitiated = true;

    
    private void OnEnable()
    {
        GameManager.Instance.currElementSize++;
        var hitObjects = Physics2D.CircleCastAll(transform.position, 1f, Vector2.zero,1f,gameObject.layer);
        Debug.Log(hitObjects.Length);
        foreach (var hitObj in hitObjects)
        {
            if(hitObj.transform.GetComponent<Rigidbody2D>())
                AddExplosionForce(hitObj.transform.GetComponent<Rigidbody2D>(),transform.position,100f);  
        }

        Instantiate(appearEffect, transform);
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameManager.Instance.currElementSize++;
    }

    public List<BodyBaseBehavour> MultiplyBody(int currMultiplyAmount)
    {
        List<BodyBaseBehavour> newBodies = new List<BodyBaseBehavour>();
        Debug.Log("Multiply");
        for (var i = 0; i <= enlargeLevel+2; i++)
        {
            var newBody = Instantiate(gameObject, null, true).GetComponent<BodyBaseBehavour>();
            newBody.transform.localScale = Vector3.one*0.3f;
            newBody.enlargeLevel = 0;
            newBodies.Add(newBody);
        }
        Destroy(gameObject,0.1f);
        return newBodies;
    }

    public void EnlargeBody()
    {
        Debug.Log("Enlarge");
        maxEnlargeLevel = GameManager.Instance.maxEnlargeLevel;
        if(enlargeLevel>maxEnlargeLevel)
            return;
        transform.localScale *= GameManager.Instance.currEnlargeAmountDelta;
        enlargeLevel += 1;
    }

    public void ShootBody(Vector2 direction)
    {
        direction.y += 3f;
        rb.AddForce(direction*currMoveForce,ForceMode2D.Impulse);
        //AddExplosionForce(rb,transform.position,currMoveForce,1f,5);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isInitiated)
        {
            
        }
    }

    public void AddExplosionForce( Rigidbody2D _rb, Vector3 origin, float explosionForce, float explosionRadius = 1f, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Impulse) 
    {
        Vector2 explosionDir = _rb.transform.position - origin;
        var explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        Vector2 force = explosionDir * Mathf.Lerp(0, explosionForce, (1 - explosionDistance));
        _rb.AddForce(force, mode);
       
    }

    private void OnDestroy()
    {
        GameManager.Instance.currElementSize--;
    }
}
