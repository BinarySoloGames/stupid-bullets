using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    [SerializeField] 
    private TimeManager timeManager;

    [SerializeField] 
    private Transform endTransform;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 startScale;
    private Vector3 endScale = new Vector3(60.0f, 60.0f, 60.0f);
    private readonly float duration = 45.0f;
    private float timeLeft;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = endTransform.position;
        startScale = transform.localScale;
        timeLeft = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.TimeLeft < timeLeft)
        {
            timeLeft = timeManager.TimeLeft;
            transform.position = Vector3.Lerp(startPosition, endPosition, (duration - timeLeft) / duration);
            transform.localScale = Vector3.Lerp(startScale, endScale, (duration - timeLeft) / duration);
        }
    }
}
