using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Handles the npc dialogue and quest/item dialogue with triggers 
/// </summary>

public class NPCInteractControl : MonoBehaviour
{
    [SerializeField] private bool _nearNPC = false;
    [SerializeField] private bool _nearNecklace = false;

    [SerializeField] private GameObject _npcControlsText;

    [SerializeField] private GameObject _npcInteractCamera;

    [SerializeField] private GameObject _npcInteractDialogueCanvas;
    [SerializeField] private GameObject _npcInteractDialogue;

    [SerializeField] private bool _firstInteraction = true;
    [SerializeField] private bool _repeatingInteraction = false;
    [SerializeField] private bool _mapObtained = false;
    [SerializeField] private bool _necklaceObtained = false;

    void Start()
    {
        QuestEvents.NecklaceObtained.AddListener(NecklaceObtained);
        QuestEvents.MapObtained.AddListener(MapObtained);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_nearNPC)
            {
                if (_necklaceObtained)
                {
                    _npcInteractCamera.SetActive(true);
                    _npcInteractDialogueCanvas.SetActive(true);
                    _npcInteractDialogue.GetComponent<TextMeshProUGUI>().text = $"Thank you for getting it back doctor! \nNow I can truly ascend to my true power... \n                 **TO BE CONTINUED**";
                    QuestEvents.QuestComplete.Invoke();
                }
                else
                {
                    if (_firstInteraction)
                    {
                        _npcInteractCamera.SetActive(true);
                        _npcInteractDialogueCanvas.SetActive(true);
                        QuestEvents.QuestStart.Invoke();
                        _firstInteraction = false;
                    }
                    else if (!_firstInteraction && !_repeatingInteraction)
                    {
                        _npcInteractCamera.SetActive(false);
                        _npcInteractDialogueCanvas.SetActive(false);
                        _repeatingInteraction = true;
                        _npcInteractDialogue.GetComponent<TextMeshProUGUI>().text = $"Please hurry before it becomes day! \nThe last skeleton is particularly tough.";
                    }
                    else if (_repeatingInteraction && !_firstInteraction)
                    {
                        _npcInteractCamera.SetActive(true);
                        _npcInteractDialogueCanvas.SetActive(true);
                        _repeatingInteraction = false;
                    }
                }
            }

            if (!_nearNPC)
            {
                _npcInteractCamera.SetActive(false);
                _npcInteractDialogueCanvas.SetActive(false);
            }

            if (_nearNecklace && _mapObtained)
            {
                QuestEvents.DigForNecklace.Invoke();
            }
        }

        if (!_nearNecklace && !_nearNPC)
        {
            _npcInteractDialogueCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            _npcControlsText.SetActive(true);
            _npcControlsText.GetComponent<TextMeshProUGUI>().text = "Press F to talk to Celine";
            _nearNPC = true;
        }

        if (other.gameObject.tag == "Dig" && _mapObtained)
        {
            _npcControlsText.SetActive(true);
            _npcControlsText.GetComponent<TextMeshProUGUI>().text = "Press F to dig";
            _nearNecklace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            _npcControlsText.SetActive(false);
            _nearNPC = false;
        }

        if (other.gameObject.tag == "Dig" && _mapObtained)
        {
            _npcControlsText.SetActive(false);
            _nearNecklace = false;
        }
    }

    void MapObtained()
    {
        _mapObtained = true;
    }

    void NecklaceObtained()
    {
        _necklaceObtained = true;
    }
}
