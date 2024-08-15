using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 25.0f;

    [SerializeField]
    private Rigidbody body;

    private bool canMove = false;
    

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector3 xz = transform.forward * speed;
            xz.y = body.velocity.y;
            body.velocity = xz;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        canMove = true;
    }
}
