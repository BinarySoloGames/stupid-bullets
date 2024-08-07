using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterDuration : MonoBehaviour
{
    [SerializeField]
    private float duration = 6.0f;

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
