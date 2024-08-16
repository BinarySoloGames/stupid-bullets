using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBySpawner : MonoBehaviour
{
    [Serializable]
    private class FlightPath
    {
        public Transform start;
        public Transform end;
    }
    
    [Serializable]
    private class FlyByInfo
    {
        public GameObject prefab;
        public float secondsUntilTrigger = 30.0f;
        public float secondsOnPath = 10.0f;
        public GameObject flyObject;
        public FlightPath flightPath;
        
        [HideInInspector]
        public float timer = 0.0f;

        [HideInInspector] 
        public bool waitingToSpawn = true;

        public bool ShouldSpawn()
        {
            return waitingToSpawn && timer >= secondsUntilTrigger;
        }

        public bool ShouldDisappear()
        {
            return waitingToSpawn == false && flyObject != null && timer >= secondsOnPath;
        }
    }

    [SerializeField]
    private List<FlyByInfo> flyObjects = new List<FlyByInfo>();
    [SerializeField] 
    private List<FlightPath> flightPaths = new List<FlightPath>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < flyObjects.Count; i++)
        {
            flyObjects[i].waitingToSpawn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < flyObjects.Count; i++)
        {
            flyObjects[i].timer += Time.deltaTime;

            if (flyObjects[i].ShouldSpawn())
            {
                flyObjects[i].timer = 0.0f;
                GameObject flyByObject = GameObject.Instantiate(flyObjects[i].prefab, transform);
                flyObjects[i].flightPath = flightPaths.PickRandom();
                flyByObject.transform.position = flyObjects[i].flightPath.start.position;
                Vector3 direction = flyObjects[i].flightPath.end.position - flyObjects[i].flightPath.start.position;
                flyByObject.transform.forward = direction.normalized;
                flyByObject.GetComponent<Rigidbody>().velocity = direction / flyObjects[i].secondsOnPath;
                flyByObject.GetComponent<Animator>().SetTrigger("Appear");
                flyObjects[i].flyObject = flyByObject;
            }
            else if (flyObjects[i].ShouldDisappear())
            {
                flyObjects[i].timer = 0.0f;
                flyObjects[i].flyObject.GetComponent<Animator>().SetTrigger("Disappear");
                StartCoroutine(DestroyFlyAfterDelay(flyObjects[i]));
            }
        }
    }

    private IEnumerator DestroyFlyAfterDelay(FlyByInfo flyInfo)
    {
        yield return new WaitForSeconds(1.0f);
        
        Destroy(flyInfo.flyObject);
        flyInfo.flyObject = null;
        flyInfo.flightPath = null;
    }
}
