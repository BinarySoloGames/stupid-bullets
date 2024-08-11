using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioContactList : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> clips = new List<AudioClip>();

    private AudioSource source;
    private bool audioPlayed = false;

    private void Start()
    {
        audioPlayed = false;
        source = GetComponent<AudioSource>();
        source.clip = clips.PickRandom();
        source.clip.LoadAudioData();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (audioPlayed || other.gameObject.CompareTag("Bullet") == false)
        {
            return;
        }

        audioPlayed = true;
        source.Play();
    }
}
