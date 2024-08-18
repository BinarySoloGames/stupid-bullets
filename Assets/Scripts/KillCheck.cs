using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class KillCheck : MonoBehaviour
{
    [SerializeField]
    private bool checkForKill = false;
    public bool unparentChildren = false;
    public bool unparentSiblings = false;
    public bool unparent = false;
    public bool killVelocity = false;
    public bool CheckForKill
    {
        get
        {
            return checkForKill;
        }
        set
        {
            checkForKill = value;
            enabled = value;
        }
    }

    public void Start()
    {
        if (checkForKill == false)
        {
            enabled = false;
        }
    }

    public void Update()
    {
        if (gameObject.CompareTag("Bullet"))
        {
            if (checkForKill && transform.position.y < -25)
            {
                Instantiate(ContentLibrary.instance.ringoutVFX, transform.position, default);
                Destroy(gameObject);
            }
        }
        else
        {
            if (checkForKill && transform.position.y < 0)
            {
                Instantiate(ContentLibrary.instance.ringoutVFX, transform.position, default);
                Destroy(gameObject);
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        CheckForKill = true;
        if (unparentChildren)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Rigidbody childBody = transform.GetChild(i).GetComponent<Rigidbody>();
                if (childBody != null)
                {
                    childBody.isKinematic = false;
                }
            }
            transform.DetachChildren();
        }

        if (unparentSiblings && transform.parent != null)
        {
            transform.parent.DetachChildren();
        }

        if (unparent && other.gameObject.CompareTag("Bullet"))
        {
            transform.SetParent(null);
        }
        else if (unparent)
        {
            GoalObject otherGoalObject = other.gameObject.GetComponent<GoalObject>();
            if (otherGoalObject != null && otherGoalObject.ProjectileID > 0)
            {
                transform.SetParent(null);
            }
        }

        if (killVelocity)
        {
            Rigidbody body = GetComponent<Rigidbody>();
            body.useGravity = true;
            body.velocity = body.velocity / 3.0f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        CheckForKill = true;
    }
}
