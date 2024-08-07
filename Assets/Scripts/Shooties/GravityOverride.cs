using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityOverride : MonoBehaviour
{
    [SerializeField] private float gravityScale = 1.0f;
    private Rigidbody body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.AddForce(Physics.gravity * gravityScale);
    }
}
