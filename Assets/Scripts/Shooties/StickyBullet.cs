using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private Collider trigger;
    
    public void OnTriggerEnter(Collider other)
    {
        rigidbody.isKinematic = true;
    }

    public void OnCollisionEnter(Collision other)
    {
        rigidbody.isKinematic = true;
        trigger.isTrigger = true;
    }
}
