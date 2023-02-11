using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovements : MonoBehaviour
{
    [SerializeField] private Transform eyeInternal;
    public Transform interactCircle;
    void Start()
    {
        eyeInternal.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactCircle && interactCircle.gameObject.activeInHierarchy)
        {
            var direction = interactCircle.position - transform.position;
            eyeInternal.GetComponent<Rigidbody2D>().AddForce(direction*10f);
            return;
        }
        eyeInternal.transform.localPosition = Vector3.zero;
    }
}
