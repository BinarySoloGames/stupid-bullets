using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using UnityEngine.UIElements;

public class DiscoveryPercentWatcher : MonoBehaviour
{
    [SerializeField]
    private DiscoveryPercentageManager discovery;
    private Label discoveryLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        UIDocument ui = GetComponent<UIDocument>();
        discoveryLabel = ui.rootVisualElement.Q<Label>("DiscoveryPercentValue");
        discoveryLabel.text = "0.0%";
        
        discovery.OnDiscoveryPercentChanged += HandleDiscoveryPercentageChanged;
    }

    private void HandleDiscoveryPercentageChanged(float oldpercent, float newpercent)
    {
        discoveryLabel.text = String.Format("{0}%", newpercent.ToString("0.00"));
    }
}
