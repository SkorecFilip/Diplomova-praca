using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShot : MonoBehaviour
{
    public void ScreenS()
    {
        string currentTime = System.DateTime.Now.ToString("dd-MM-yy (HH-mm-ss)");
        Camera cam = GetComponent<Camera>();
        RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
        cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        cam.Render();
        Texture2D renderedTexture = new Texture2D(Screen.width, Screen.height);
        renderedTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;
        byte[] byteArray = renderedTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/../foto/cameracapture" + currentTime +".png", byteArray);
    }
}
