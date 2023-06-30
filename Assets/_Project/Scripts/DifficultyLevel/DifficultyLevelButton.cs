using System;
using System.Collections;
using System.Collections.Generic;
using ManagersAndControllers.Spawner;
using UnityEngine;
using UnityEngine.UI;

namespace Radgar.Difficulty
{
    public class DifficultyLevelButton : MonoBehaviour
    {
        [SerializeField] private Difficulty _difficulty;
        [SerializeField] private GameSpawner _gameSpawner;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(SetDifficultyLevel);
        }


        private void SetDifficultyLevel()
        {
            _gameSpawner._difficulty = _difficulty;
        }
    }
}


