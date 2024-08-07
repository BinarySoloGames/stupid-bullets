using System;
using UnityEngine;

namespace Gameplay
{
    public class GoalObject : MonoBehaviour
    {
        public int Score = 10;
        
        public delegate void GoalObjectDestroyed(GoalObject goalObject);
        public event GoalObjectDestroyed OnGoalObjectDestroyed;

        public void OnDestroy()
        {
            OnGoalObjectDestroyed?.Invoke(this);
        }
    }
}