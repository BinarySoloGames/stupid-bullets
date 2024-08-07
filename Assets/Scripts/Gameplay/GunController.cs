using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] 
    private Transform spawnPoint;
    [SerializeField] 
    private List<GameObject> bullets;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
