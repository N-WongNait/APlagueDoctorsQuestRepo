using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZoomInAndOut : MonoBehaviour
{
    public InputAction ZoomAction; 
    public InputAction ResetAction;

    [SerializeField] private float _zoomSpeed = 10.0f;

    [SerializeField] private GameObject _defaultZoomPos, _maxZoomInPos, _maxZoomOutPos;

    private void Update()
    {
        if (ZoomAction.ReadValue<float>() > 0)
        {
            transform.Translate(Vector3.forward * _zoomSpeed * Time.deltaTime, Space.Self);
            if (transform.localPosition.z > -1.5f)
            {
                transform.position = _maxZoomInPos.transform.position;
            }
        }

        if (ZoomAction.ReadValue<float>() < 0)
        {
            transform.Translate(-Vector3.forward * _zoomSpeed * Time.deltaTime, Space.Self);
            if (transform.localPosition.z < -3f)
            {
                transform.position = _maxZoomOutPos.transform.position;
            }
        }

        if (ResetAction.ReadValue<float>() == 1)
        {
            transform.position = _defaultZoomPos.transform.position;
        }
    }

    private void OnEnable()
    {
        ZoomAction.Enable();
        ResetAction.Enable();
    }

    private void OnDisable()
    {
        ZoomAction.Disable();
        ResetAction.Disable();
    }

    //Clamp position.z -1 max zoom in -3 max zoom out
}
