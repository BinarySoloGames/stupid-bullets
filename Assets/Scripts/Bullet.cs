using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float Speed = 10.0f;
    
    public void Fire()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }
}