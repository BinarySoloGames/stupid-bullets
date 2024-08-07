using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class KinematicKiller : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.attachedRigidbody.isKinematic)
        {
            other.attachedRigidbody.isKinematic = false;
        }

        GoalObject parentObject = other.GetComponentInParent<GoalObject>();
        if (parentObject)
        {
            parentObject.GetComponent<Rigidbody>().isKinematic = false;
            foreach (Rigidbody childBody in parentObject.GetComponentsInChildren<Rigidbody>())
            {
                childBody.isKinematic = false;
            }
        }
    }
}
