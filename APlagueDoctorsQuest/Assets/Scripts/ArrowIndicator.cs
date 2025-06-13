using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When the digspot becoomes active have the arrow indicator point towards it
/// </summary>

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _necklaceDigSpot;

    private void Update()
    {
        if (_necklaceDigSpot != null)
        {
            Vector3 digPosition = new Vector3(transform.position.x, _necklaceDigSpot.transform.position.y, _necklaceDigSpot.transform.position.z);
            transform.LookAt(digPosition);
        }
    }
}
