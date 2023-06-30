using System;
using System.Collections;
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
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _photoTakenPanel;

        [Header("Start Game Steps Panels")] 
        [SerializeField] private GameObject _chooseLevel;
        [SerializeField] private GameObject _enterName;
        
        
        private void Awake()
        {
            EventManager.instance._startGame.AddListener(AddName);
            EventManager.instance._endGame.AddListener(EndPanel);
            EventManager.instance._winGame.AddListener(WinPanel);
        }

        private void Start()
        {
            ActiveTypeOfPanel(0);
        }

        private void AddName()
        {
            GameManager.instance.playerName = _nameInputField.text;
        }

        private void EndPanel()
        {
            ActiveTypeOfPanel(2);
        }

        private void WinPanel()
        {
            Debug.Log("Win");
            ActiveTypeOfPanel(3);
        }

        public void ActiveTypeOfPanel(int id)
        {
            switch (id)
            {
                case 0:
                    _menuPanel.SetActive(true);
                    _gamePlayPanel.SetActive(false);
                    _gameOverPanel.SetActive(false);
                    _winPanel.SetActive(false);
                    break;
                case 1:
                    _menuPanel.SetActive(false);
                    _gamePlayPanel.SetActive(true);
                    _gameOverPanel.SetActive(false);
                    _winPanel.SetActive(false);
                    break;
                case 2:
                    _menuPanel.SetActive(false);
                    _gamePlayPanel.SetActive(false);
                    _gameOverPanel.SetActive(true);
                    break;
                case 3:
                    _menuPanel.SetActive(false);
                    _gamePlayPanel.SetActive(false);
                    _gameOverPanel.SetActive(false);
                    _winPanel.SetActive(true);
                    break;
            }
        }

        public void SetStartPanels()
        {
            _chooseLevel.SetActive(true);
            _enterName.SetActive(false);
        }
        
        public void PhotoTakenInfo()
        {
            StartCoroutine(PhotoTakenInfoWithTime());
        }

        IEnumerator PhotoTakenInfoWithTime()
        {
            _photoTakenPanel.SetActive(true);
            yield return new WaitForSeconds(2);
            _photoTakenPanel.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
        
    }
}