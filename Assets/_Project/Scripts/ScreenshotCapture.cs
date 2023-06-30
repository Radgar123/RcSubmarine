using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ManagersAndControllers;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenshotCapture : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void CreateScreenshotFromCameraView()
    {
        
    }

    public void CaptureScreenshot()
    {
        string folderPath = Path.Combine(Application.dataPath, "screenshoot");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string fileName = $"screenshot_{timestamp}.png";
        string filePath = Path.Combine(folderPath, fileName);

        ScreenCapture.CaptureScreenshot(Path.Combine(folderPath, fileName));
        Debug.Log("Screenshot saved: " + filePath);
        
        if (GameManager.instance.winPosition)
        {
            EventManager.instance.WinGame();
        }
    }
}
