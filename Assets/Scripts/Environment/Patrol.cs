using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    // Set this to the closest point on the patrol.
    private int nextPoint = 0;
    [SerializeField]
    private float speed = 5.0f;

    private Tween moveTween;
    private Tween rotateTween;
    
    // Start is called before the first frame update
    void Start()
    {
        float duration = Vector3.Distance(transform.position, points[nextPoint].position) / speed;
        moveTween = transform.DOMove(points[nextPoint].position, duration)
            .SetEase(Ease.Linear)
            .OnComplete(MoveToNextPoint);
        transform.LookAt(points[nextPoint].position);
    }

    private void MoveToNextPoint()
    {
        nextPoint++;
        if (nextPoint == points.Length)
        {
            nextPoint = 0;
        }
        
        float duration = Vector3.Distance(transform.position, points[nextPoint].position) / speed;
        moveTween = transform.DOMove(points[nextPoint].position, duration)
            .SetEase(Ease.Linear)
            .OnComplete(MoveToNextPoint);
        transform.LookAt(points[nextPoint].position);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        moveTween.Kill();
    }
}