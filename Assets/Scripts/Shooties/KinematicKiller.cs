using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicKiller : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.attachedRigidbody.isKinematic)
        {
            other.attachedRigidbody.isKinematic = false;
        }
    }
}
