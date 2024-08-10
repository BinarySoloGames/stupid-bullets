using System;
using UnityEngine;

namespace Gameplay
{
    public class GoalObject : MonoBehaviour
    {
        public enum GoalArea
        {
            None,
            Farm,
            ParkingLot,
            Graveyard
        };
        
        public int Score = 10;
        public float TimeBonus = 0.0f;
        public int ProjectileID = -1;
        public GoalArea Area = GoalArea.None; 
        
        public delegate void GoalObjectDestroyed(GoalObject goalObject);
        public event GoalObjectDestroyed OnGoalObjectDestroyed;

        public void OnDestroy()
        {
            OnGoalObjectDestroyed?.Invoke(this);
        }

        public void OnCollisionEnter(Collision other)
        {
            Bullet bulletComp = other.gameObject.GetComponent<Bullet>();
            if (bulletComp != null)
            {
                ProjectileID = bulletComp.ProjectileID;
                return;
            }

            GoalObject goalComp = other.gameObject.GetComponent<GoalObject>();
            if (goalComp != null)
            {
                ProjectileID = goalComp.ProjectileID;
            }
        }
    }
}