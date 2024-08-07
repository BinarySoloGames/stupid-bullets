using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadiusWatcher : MonoBehaviour
{
    [SerializeField]
    private SphereCollider collider;

    // Update is called once per frame
    void Update()
    {
        if (collider != null)
        {
            transform.localScale = new Vector3(collider.radius, collider.radius, collider.radius);
        }
    }
}
