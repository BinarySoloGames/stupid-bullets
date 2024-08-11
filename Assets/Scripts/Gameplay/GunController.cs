using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] 
    private Transform spawnPoint;
    [SerializeField] 
    private int numSpecialBullets = 5;
    [SerializeField] 
    private List<GameObject> bullets;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bulletInstance = GameObject.Instantiate(bullets.PickRandom());
            bulletInstance.transform.position = spawnPoint.position;
            bulletInstance.transform.forward = spawnPoint.forward;
            bulletInstance.GetComponent<Bullet>().Fire();
        }
    }

    public void ChangeBullet(Bullet specialBullet)
    {
        for (int i = 0; i < numSpecialBullets; i++)
        {
            bullets[bullets.Count - i - 1] = specialBullet.gameObject;
        }
    }
}
