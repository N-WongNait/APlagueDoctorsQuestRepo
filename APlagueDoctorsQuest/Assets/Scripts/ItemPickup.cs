using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the multiple item pickups the player need for the quest
/// </summary>

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Map")
        {
            QuestEvents.MapObtained.Invoke();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Necklace")
        {
            QuestEvents.NecklaceObtained.Invoke();
            Destroy(other.gameObject);
        }
    }
}
