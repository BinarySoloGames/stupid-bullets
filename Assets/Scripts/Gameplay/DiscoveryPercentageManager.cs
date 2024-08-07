using UnityEngine;

namespace Gameplay
{
    public class DiscoveryPercentageManager : MonoBehaviour
    {
        public float discoveryPercent = 0;
        private float objectsTotal = 1;
        private float objectsDestroyed = 0;
    
        public delegate void DiscoveryPercentChanged(float oldPercent, float newPercent);
        public event DiscoveryPercentChanged OnDiscoveryPercentChanged;
    
        // Start is called before the first frame update
        void Start()
        {
            GoalObject[] goalObjects = FindObjectsByType<GoalObject>(FindObjectsSortMode.None);
            objectsTotal = goalObjects.Length;
            for (int i = 0; i < goalObjects.Length; i++)
            {
                goalObjects[i].OnGoalObjectDestroyed += HandleGoalObjectDestroyed;
            }
        }

        public void HandleGoalObjectDestroyed(GoalObject goalObject)
        {
            float oldPercent = discoveryPercent;
            objectsDestroyed += goalObject.Score;
            discoveryPercent = objectsTotal / objectsDestroyed;
            OnDiscoveryPercentChanged?.Invoke(oldPercent, discoveryPercent);

            goalObject.OnGoalObjectDestroyed -= HandleGoalObjectDestroyed;
        }
    }
}
