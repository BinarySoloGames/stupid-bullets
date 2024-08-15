using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentLibrary : MonoBehaviour
{
    public static ContentLibrary instance;

    public GameObject ringoutVFX;

    private void Awake()
    {
        instance = this;
    }
}
