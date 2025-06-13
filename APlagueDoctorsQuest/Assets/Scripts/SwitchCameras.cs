using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    [SerializeField] private GameObject _thirdPersonCamera;
    [SerializeField] private GameObject _firstPersonCamera;
    [SerializeField] private GameObject _firstPersonStaff;
    [SerializeField] private GameObject _thirdPersonStaff;

    private Staff _firstPersonStaffScript;
    private Staff _thirdPersonStaffScript;

    private enum CameraMode
    {
        ThirdPerson,
        FirstPerson
    }

    private CameraMode currentCameraMode;

    void Awake()
    {
        _firstPersonStaffScript = _firstPersonStaff.GetComponent<Staff>();
        _thirdPersonStaffScript = _thirdPersonStaff.GetComponent<Staff>();

        currentCameraMode = CameraMode.ThirdPerson;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        if (currentCameraMode == CameraMode.ThirdPerson)
        {
            _firstPersonCamera.SetActive(true);
            _thirdPersonCamera.SetActive(false);

            _firstPersonStaffScript.IsActiveStaff = true;
            _thirdPersonStaffScript.IsActiveStaff = false;

            currentCameraMode = CameraMode.FirstPerson;
        }
        else if (currentCameraMode == CameraMode.FirstPerson)
        {
            _thirdPersonCamera.SetActive(true);
            _firstPersonCamera.SetActive(false);

            _thirdPersonStaffScript.IsActiveStaff = true;
            _firstPersonStaffScript.IsActiveStaff = false;

            currentCameraMode = CameraMode.ThirdPerson;
        }
    }
}
