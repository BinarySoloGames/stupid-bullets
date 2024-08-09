using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    private Button replayButton;

    [SerializeField]
    private TimeManager timeManager;

    private bool addedClickEvent = false;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        replayButton = ui.rootVisualElement.Q<Button>("TryAgainButton");
        addedClickEvent = false;
    }

    private void Update()
    {
        if (addedClickEvent == false && timeManager.TimeLeft < 0.0f)
        {
            addedClickEvent = true;
            UIDocument ui = GetComponent<UIDocument>();
            replayButton = ui.rootVisualElement.Q<Button>("TryAgainButton");
            replayButton.RegisterCallback<ClickEvent>(evt => 
            {
                Debug.Log("Replay clicked.");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }
    }
}
