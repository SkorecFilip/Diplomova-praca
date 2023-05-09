using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public CameraShot cameraShot;
    private void OnTriggerEnter(Collider other)
    {
        cameraShot.ScreenS();
    }
}
