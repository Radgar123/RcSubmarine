using System;
using System.Collections;
using System.Collections.Generic;
using ManagersAndControllers;
using ManagersAndControllers.SaveManager;
using TMPro;
using UnityEngine;

public class DisplayLeaderBoards : MonoBehaviour
{
    [SerializeField] private SaveManager _saveManager;
    
    [Header("High Scores")] 
    [SerializeField] private TextMeshProUGUI firstPlace;
    [SerializeField] private TextMeshProUGUI secondPlace;
    [SerializeField] private TextMeshProUGUI thirdPlace;
    [Header("CurrentPlayerScreen")] [SerializeField]
    private TextMeshProUGUI yourScores;

    private void OnEnable()
    {
        DisplayYourScores();
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        Debug.Log(_saveManager._saveData._saveDataObjects.Count);
        _saveManager.SortData();
        
        if (_saveManager._saveData._saveDataObjects.Count >= 0)
        {
            firstPlace.text = "1. " + _saveManager._saveData._saveDataObjects[0].name + " " +
                              _saveManager._saveData._saveDataObjects[0].time;
        }
        else
        {
            firstPlace.text = "...";
        }
        
        if (_saveManager._saveData._saveDataObjects.Count >= 1)
        {
            secondPlace.text = "2. " + _saveManager._saveData._saveDataObjects[1].name + " " +
                              _saveManager._saveData._saveDataObjects[1].time;
        }
        else
        {
            secondPlace.text = "...";
        }
        
        if (_saveManager._saveData._saveDataObjects.Count >= 2)
        {
            thirdPlace.text = "3. " + _saveManager._saveData._saveDataObjects[1].name + " " +
                              _saveManager._saveData._saveDataObjects[1].time;
        }
        else
        {
            thirdPlace.text = "...";
        }
        
        Debug.Log(_saveManager._saveData._saveDataObjects.Count);
    }

    private void DisplayYourScores()
    {
        yourScores.text = "Your Scores: " + GameManager.instance.playerName + 
                          " " + GameManager.instance.playerTime;
    }
}
