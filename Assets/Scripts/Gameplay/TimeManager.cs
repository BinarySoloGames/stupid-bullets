using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] 
    private ScoreController scoreController;
    
    [SerializeField]
    private float AreaTimeBonus = 15.0f;

    [SerializeField]
    private float gameLength = 60.0f * 10.0f;
    public float TimeLeft = 60.0f * 10.0f;
    
    private Dictionary<GoalObject.GoalArea, int> goalAreas = new Dictionary<GoalObject.GoalArea, int>();
    
    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = gameLength;
        
        foreach (GoalObject.GoalArea value in Enum.GetValues(typeof(GoalObject.GoalArea)))
        {
            goalAreas[value] = 0;
        }
            
        GoalObject[] goalObjects = FindObjectsByType<GoalObject>(FindObjectsSortMode.None);
        for (int i = 0; i < goalObjects.Length; i++)
        {
            goalObjects[i].OnGoalObjectDestroyed += HandleGoalObjectDestroyed;
            goalAreas[goalObjects[i].Area] += 1;
        }
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

    public void HandleGoalObjectDestroyed(GoalObject goalObject)
    {
        TimeLeft += goalObject.TimeBonus;
        
        goalAreas[goalObject.Area] -= 1;
        if (goalAreas[goalObject.Area] <= 0)
        {
            TimeLeft += AreaTimeBonus;
        }
    }
}
