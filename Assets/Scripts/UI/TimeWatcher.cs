using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeWatcher : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;
    private Label timeLabel;
    private VisualElement gameOverElement;
    
    // Start is called before the first frame update
    void Start()
    {
        UIDocument ui = GetComponent<UIDocument>();
        timeLabel = ui.rootVisualElement.Q<Label>("TimeLabel");
        gameOverElement = ui.rootVisualElement.Q<VisualElement>("GameOverElement");
    }

    // Update is called once per frame
    void Update()
    {
        timeLabel.text = $"{Mathf.Max(0, (int)(timeManager.TimeLeft / 60.0f)):00}:{Mathf.Max(0, (int)timeManager.TimeLeft % 60):00}";

        if (gameOverElement.resolvedStyle.visibility == Visibility.Hidden && timeManager.TimeLeft <= 0.0f)
        {
            gameOverElement.style.visibility = Visibility.Visible;
        }
    }
}
