using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("QuitGame");
            Application.Quit();
        }
    }
}
