using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public AudioClip bgm;
    public Bullet specialBullet;

    private void Start()
    {
        bgm.LoadAudioData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource bgmPlayer = other.gameObject.GetComponent<AudioSource>();
            bgmPlayer.clip = bgm;
            bgmPlayer.Play();

            GunController gun = other.gameObject.GetComponentInChildren<GunController>();
            gun.ChangeBullet(specialBullet);
        }
    }
}
