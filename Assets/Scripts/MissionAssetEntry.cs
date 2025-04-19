using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionAssetEntry : MonoBehaviour
{
    public TMP_Dropdown assetDropdown;
    public TMP_InputField quantityField;
    public Button removeAssetButton;

    private MissionAssetList assetList;

    public System.Action<MissionAssetEntry> onRemoveClicked;

    public void Init(MissionAssetList listReference)
    {
        assetList = listReference;

        //Unsubscribe from the listeners to allow reuse of the prefab
        removeAssetButton.onClick.RemoveAllListeners();
        removeAssetButton.onClick.AddListener(OnRemoveClicked);
    }

    private void OnRemoveClicked()
    {
        assetList.RemoveAssetEntry(this);
    }
}
