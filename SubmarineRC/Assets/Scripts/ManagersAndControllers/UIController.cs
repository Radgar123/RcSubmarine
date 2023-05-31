using System;
using TMPro;
using UnityEngine;

namespace ManagersAndControllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _gamePlayPanel;
        [SerializeField] private GameObject _gameOverPanel;

        //private int panelId;
        
        private void Awake()
        {
            EventManager.instance._startGame.AddListener(AddName);
        }

        private void Start()
        {
            ActiveTypeOfPanel(0);
        }

        private void AddName()
        {
            GameManager.instance.playerName = _nameInputField.text;
        }

        public void ActiveTypeOfPanel(int id)
        {
            switch (id)
            {
                case 0:
                    _menuPanel.SetActive(true);
                    _gamePlayPanel.SetActive(false);
                    _gameOverPanel.SetActive(false);
                    break;
                case 1:
                    _menuPanel.SetActive(false);
                    _gamePlayPanel.SetActive(true);
                    _gameOverPanel.SetActive(false);
                    break;
                case 2:
                    _menuPanel.SetActive(false);
                    _gamePlayPanel.SetActive(false);
                    _gameOverPanel.SetActive(true);
                    break;
            }
        }
    }
}