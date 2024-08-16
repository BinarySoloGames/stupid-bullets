using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] 
    private List<Transform> spawnPoints = new List<Transform>();
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        MovePlayerToSpawn(player.transform);
    }

    public void MovePlayerToSpawn(Transform player)
    {
        Transform randomSpawn = spawnPoints.PickRandom();
        player.position = randomSpawn.position;
        player.rotation = randomSpawn.rotation;
    }
}
