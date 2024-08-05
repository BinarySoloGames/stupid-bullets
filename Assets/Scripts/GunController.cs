using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject nuke;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var bulletInstance = GameObject.Instantiate(bullet);
            bulletInstance.transform.position = spawnPoint.position;
            bulletInstance.transform.forward = spawnPoint.forward;
            bulletInstance.GetComponent<Bullet>().Fire();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            var bulletInstance = GameObject.Instantiate(nuke);
            bulletInstance.transform.position = spawnPoint.position;
            bulletInstance.transform.forward = spawnPoint.forward;
            bulletInstance.GetComponent<Bullet>().Fire();
        }
    }
}
