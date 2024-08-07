using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceVelocity : MonoBehaviour
{
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.forward = body.velocity;
    }
}
