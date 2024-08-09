using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float gameLength = 60.0f * 10.0f;
    public float TimeLeft = 60.0f * 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = gameLength;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0.0f)
        {
            FindObjectOfType<FirstPersonController>().enabled = false;
            FindObjectOfType<GunController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            enabled = false;
        }
    }
}
