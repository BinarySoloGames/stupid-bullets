using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    class GoalObjectComboInfo
    {
        public float timer;
        public int goalObjects;
    };
    
    public class ScoreController : MonoBehaviour
    {
        public int Score = 0;
    
        public delegate void ScoreChanged(int score);
        public event ScoreChanged OnScoreChanged;
        
        private Dictionary<int, GoalObjectComboInfo> combos = new Dictionary<int, GoalObjectComboInfo>();
    
        // Start is called before the first frame update
        void Start()
        {
            GoalObject[] goalObjects = FindObjectsByType<GoalObject>(FindObjectsSortMode.None);
            for (int i = 0; i < goalObjects.Length; i++)
            {
                goalObjects[i].OnGoalObjectDestroyed += HandleGoalObjectDestroyed;
            }
        }

        private void Update()
        {
            List<int> toRemove = new List<int>();
            foreach (var KVP in combos)
            {
                KVP.Value.timer -= Time.deltaTime;
                if (KVP.Value.timer <= 0.0f)
                {
                    toRemove.Add(KVP.Key);
                }
            }

            for (int i = 0; i < toRemove.Count; i++)
            {
                combos.Remove(toRemove[i]);
            }
        }

        public void HandleGoalObjectDestroyed(GoalObject goalObject)
        {
            goalObject.OnGoalObjectDestroyed -= HandleGoalObjectDestroyed;

            int resolvedScore = goalObject.Score;
            int bulletID = goalObject.ProjectileID;
            if (bulletID > 0)
            {
                if (combos.ContainsKey(bulletID))
                {
                    resolvedScore += combos[bulletID].goalObjects * 10; 

                    combos[bulletID].timer += 10.0f;
                    combos[bulletID].goalObjects += 1;
                }
                else
                {
                    combos[bulletID] = new GoalObjectComboInfo();
                    combos[bulletID].timer = 10.0f;
                    combos[bulletID].goalObjects = 1;
                }
            }
            
            Score += resolvedScore;
            OnScoreChanged?.Invoke(Score);
        }
    }

}