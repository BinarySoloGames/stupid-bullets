using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCheck : MonoBehaviour
{
    [SerializeField]
    private bool checkForKill = false;
    public bool unparentChildren = false;
    public bool unparentSiblings = false;
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
        if (checkForKill && transform.position.y < -25.0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        CheckForKill = true;
        if (unparentChildren)
        {
            transform.DetachChildren();
        }

        if (unparentSiblings && transform.parent != null)
        {
            transform.parent.DetachChildren();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        CheckForKill = true;
    }
}
