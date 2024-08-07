using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Explosion : MonoBehaviour
{
    [SerializeField] 
    private float force = 1000.0f;
    [SerializeField]
    private float endRadius = 1.0f;
    [SerializeField] 
    private float growDuration = 1.0f;
    [SerializeField] 
    private float shrinkDuration = 1.0f;

    private SphereCollider collider;

    private void Start()
    {
        collider = GetComponent<SphereCollider>();
    }

    public void PlayExplosion()
    {
        DOTween.To(() => collider.radius, (value) => collider.radius = value, endRadius, growDuration)
            .OnComplete((
                () => DOTween.To(() => collider.radius, (value) => collider.radius = value, 0.01f, shrinkDuration)
                    .OnComplete((() => Destroy(gameObject)))));
    }
    
    public void OnTriggerEnter(Collider other)
    {
        // other.attachedRigidbody.AddExplosionForce(force, other.ClosestPoint(transform.position), collider.radius);
        // Rigidbody body = other.gameObject.GetComponent<Rigidbody>();
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.isKinematic = false;
            other.attachedRigidbody.AddExplosionForce(force, other.ClosestPoint(transform.position), collider.radius);
        }
    }
}