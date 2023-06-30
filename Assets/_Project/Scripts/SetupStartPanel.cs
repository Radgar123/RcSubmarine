using System;
using System.Collections;
using System.Collections.Generic;
using ManagersAndControllers;
using UnityEngine;

public class SetupStartPanel : MonoBehaviour
{
    [SerializeField] private UIController _uiController;

    private void OnEnable()
    {
        _uiController.SetStartPanels();
    }
}
