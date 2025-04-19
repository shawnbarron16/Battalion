using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionAssetList : MonoBehaviour
{
    [Header("References")]
    public GameObject assetEntryPrefab;
    public Transform contentParent;
    public Button addAssetButton;

    private List<MissionAssetEntry> assetEntries = new List<MissionAssetEntry>(); 

    private void Start()
    {
        addAssetButton.onClick.AddListener(SpawnNewAssetEntry);
    }

    void SpawnNewAssetEntry()
    {
        GameObject newEntry = Instantiate(assetEntryPrefab, contentParent);
        newEntry.transform.localScale = Vector3.one;

        MissionAssetEntry entryScript = newEntry.GetComponent<MissionAssetEntry>();
        if(entryScript != null)
        {
            entryScript.Init(this);
            assetEntries.Add(entryScript);
        }
        else
        {
            Debug.LogError("MissionAssetEntry script not found on instantiated prefab!");
        }
    }

    public void RemoveAssetEntry(MissionAssetEntry entry)
    {
        assetEntries.Remove(entry);
        Destroy(entry.gameObject);
    }
}
