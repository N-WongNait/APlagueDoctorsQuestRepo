using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the pickable items always facing the player
/// </summary>

public class ItemLookat : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void Awake()
    {
        // If not assigned in the Inspector, try to find by tag
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        if (_player != null)
        {
            Vector3 lookPosition = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
            transform.LookAt(lookPosition);
        }
    }
}
