using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public Camera mapCamera;

    // Start is called before the first frame update
    void Start()
    {
        mapCamera.enabled = false;
    }

    public void SetMapCamera()
    {
        playerCamera.enabled = false;
        mapCamera.enabled = true;
    }

    public void SetPlayerCamera()
    {
        mapCamera.enabled = false;
        playerCamera.enabled = true;
    }
}
