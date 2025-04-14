using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelUIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject missionsPanel;
    public GameObject resourcesPanel;
    public GameObject unitsPanel;
    public GameObject mapPanel;
    public GameObject orderAssetsPanel;

    private Dictionary<string, GameObject> panelMap;
    
    void Awake()
    {
        //Initialize the panel map
        panelMap = new Dictionary<string, GameObject>
        {
            { "Missions", missionsPanel},
            { "Resources", resourcesPanel},
            { "Units", unitsPanel},
            { "Campaign Map", mapPanel},
            { "Order Assets", orderAssetsPanel}
        };

        //Show missions panel by default
        ShowPanel("Missions");
    }

    //Disable all panels and activate the requested panel
    public void ShowPanel(string panelName)
    {
        foreach(var panel in panelMap)
        {
            panel.Value.SetActive(false);
        }

        if(panelMap.ContainsKey(panelName))
        {
            panelMap[panelName].SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Panel '{panelName}' no found");
        }
    }
}
