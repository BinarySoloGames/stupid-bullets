using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{
    public float Speed = 10.0f;
    public int ProjectileID = -1;
    private static int ProjectileIDGenerator = 0;
    
    private Rigidbody body;
    private AudioSource audioSource;

    public AudioClip ShootClip;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        ProjectileID = ++ProjectileIDGenerator;
        body.AddForce(transform.forward * Speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }
}