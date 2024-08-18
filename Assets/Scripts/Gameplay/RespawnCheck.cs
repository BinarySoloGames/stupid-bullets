using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheck : MonoBehaviour
{
    [SerializeField] 
    private SpawnController spawnController;
    private bool vfxCanSpawn = true;

    private void Start()
    {
        vfxCanSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (vfxCanSpawn && transform.position.y < -25.0f)
        {
            GameObject vfx = Instantiate(ContentLibrary.instance.ringoutVFX, transform.position, default);
            vfx.transform.SetParent(transform);
            vfxCanSpawn = false;
        }
        else if (transform.position.y < -50.0f)
        {
            vfxCanSpawn = true;
            spawnController.MovePlayerToSpawn(transform);
        }
    }
}
