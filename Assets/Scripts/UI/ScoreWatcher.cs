using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreWatcher : MonoBehaviour
{
    [SerializeField]
    private ScoreController score;
    private Label scoreLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        UIDocument ui = GetComponent<UIDocument>();
        scoreLabel = ui.rootVisualElement.Q<Label>("ScoreValue");
        scoreLabel.text = "0";
        
        score.OnScoreChanged += HandleScoreChanged;
    }

    private void HandleScoreChanged(int newScore)
    {
        scoreLabel.text = newScore.ToString();
    }
}
