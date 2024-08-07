using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosionSpawner : MonoBehaviour
{
    [SerializeField]
    private Explosion explosion;

    [SerializeField]
    private bool destroyOnExplode = true;

    private void OnCollisionEnter(Collision other)
    {
        Explosion explosionInstance = GameObject.Instantiate(explosion);
        explosionInstance.transform.position = other.contacts[0].point;
        explosionInstance.PlayExplosion();

        if (destroyOnExplode)
        {
            Destroy(gameObject);
        }
    }
}
