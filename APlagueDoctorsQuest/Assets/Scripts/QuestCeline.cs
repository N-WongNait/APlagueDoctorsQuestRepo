using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Handles all the UI and quest dialogue changes
/// </summary>

public class QuestCeline : MonoBehaviour
{
    public enum QuestState
    {
        Inactive,
        Active,
        MapObtained,
        NecklaceObtained,
        Complete
    }

    [SerializeField] private QuestState _questState = QuestState.Inactive;

    [SerializeField] private int _totalSkeletons = 3;
    [SerializeField] private int _skeletonsDefeated = 0;

    [SerializeField] private GameObject _questInstructions;
    [SerializeField] private GameObject _questDirectionsHotBar;
    [SerializeField] private GameObject _mapHotBar;
    [SerializeField] private GameObject _necklaceHotBar;

    [SerializeField] private GameObject _mapItem;
    [SerializeField] private GameObject _necklaceItem;
    [SerializeField] private GameObject _necklaceSpotlight;
    [SerializeField] private GameObject _arrowIndicator;

    void Start()
    {
        QuestEvents.QuestStart.AddListener(StartQuest);
        QuestEvents.Update.AddListener(UpdateSkeleton);
        QuestEvents.MapObtained.AddListener(UpdateMap);
        QuestEvents.DigForNecklace.AddListener(SpawnNecklace);
        QuestEvents.NecklaceObtained.AddListener(UpdateNecklace);
        QuestEvents.QuestComplete.AddListener(CompleteQuest);
    }

    // Update is called once per frame
    void Update()
    {
        //This could be handled better with a swiitch statement

        if (_questState == QuestState.Active || _questState == QuestState.MapObtained || _questState == QuestState.NecklaceObtained || _questState == QuestState.Complete)
        {
            _questInstructions.SetActive(true);
            _questInstructions.GetComponentInChildren<TextMeshProUGUI>().text = $"Defeat 3 Skeletons. \n{_skeletonsDefeated}/{_totalSkeletons} skeletons";
            _questDirectionsHotBar.SetActive(true);
        }

        if (_skeletonsDefeated == _totalSkeletons && (_questState != QuestState.MapObtained || _questState != QuestState.NecklaceObtained || _questState != QuestState.Complete))
        {
            _questInstructions.GetComponentInChildren<TextMeshProUGUI>().text = $"Take the stolen map";
        }

        if (_questState == QuestState.MapObtained || _questState == QuestState.NecklaceObtained || _questState == QuestState.Complete)
        {
            _questInstructions.GetComponentInChildren<TextMeshProUGUI>().text = $"Find the right grave to dig.";
            _mapHotBar.SetActive(true);
        }

        if (_questState == QuestState.NecklaceObtained)
        {
            _questInstructions.GetComponentInChildren<TextMeshProUGUI>().text = $"Give Celine her necklace back.";
            _necklaceHotBar.SetActive(true);
        }

        if (_questState == QuestState.Complete)
        {
            _questInstructions.GetComponentInChildren<TextMeshProUGUI>().text = $"Quest Complete \n New Quest: Stop Celine.";
            _necklaceHotBar.SetActive(false);
        }
    }

    void StartQuest()
    {
        _questState = QuestState.Active;
    }

    void UpdateSkeleton(float xPos, float yPos, float zPos)
    {
        _skeletonsDefeated++;

        if (_skeletonsDefeated == _totalSkeletons)
        {
            _mapItem.SetActive(true);
            _mapItem.transform.position = new Vector3(xPos, yPos + 1, zPos);
        }
    }

    void UpdateMap()
    {
        _questState = QuestState.MapObtained;
        _arrowIndicator.SetActive(true);
        _necklaceSpotlight.SetActive(true);
    }

    void SpawnNecklace()
    {
        _necklaceItem.SetActive(true);
    }

    void UpdateNecklace()
    {
        _questState = QuestState.NecklaceObtained;
        _necklaceSpotlight.SetActive(false);
        _arrowIndicator.SetActive(false);
    }

    void CompleteQuest()
    {
        _questState = QuestState.Complete;
    }
}
