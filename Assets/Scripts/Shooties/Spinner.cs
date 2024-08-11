using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spinner : MonoBehaviour
{
    [SerializeField] 
    private float spinSpeed = 1.0f;

    private Vector3 rotationDirection;

    private void Start()
    {
        rotationDirection = new Vector3(Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f), Random.Range(0.0f, 90.0f));
    }

    private void Update()
    {
        transform.Rotate(rotationDirection * (Time.deltaTime * spinSpeed));
    }
}
