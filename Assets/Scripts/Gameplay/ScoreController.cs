using UnityEngine;

namespace Gameplay
{
    public class ScoreController : MonoBehaviour
    {
        public int Score = 0;
    
        public delegate void ScoreChanged(int score);
        public event ScoreChanged OnScoreChanged;
    
        // Start is called before the first frame update
        void Start()
        {
            GoalObject[] goalObjects = FindObjectsByType<GoalObject>(FindObjectsSortMode.None);
            for (int i = 0; i < goalObjects.Length; i++)
            {
                goalObjects[i].OnGoalObjectDestroyed += HandleGoalObjectDestroyed;
            }
        }

        public void HandleGoalObjectDestroyed(GoalObject goalObject)
        {
            Score += goalObject.Score;
            OnScoreChanged?.Invoke(Score);

            goalObject.OnGoalObjectDestroyed -= HandleGoalObjectDestroyed;
        }
    }

}