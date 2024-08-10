using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float Speed = 10.0f;
    public int ProjectileID = -1;

    private static int ProjectileIDGenerator = 0;
    
    public void Fire()
    {
        ProjectileID = ++ProjectileIDGenerator;
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }
}