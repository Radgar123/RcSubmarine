using System;
using Radgar.Singleton;
using UnityEngine;

namespace ManagersAndControllers
{
    public class GameManager : Singleton<GameManager>
    {
        public string playerName;
        public int playerTime;
        public int gameTimeInMinutes;
        public bool gameIsEnded;
        public bool winPosition;

        public Camera mainCamera;
        //public Vector3 screenPos;

        private void Start()
        {
            /*screenPos = mainCamera.WorldToScreenPoint(transform.position);*/
        }

        public void ResetGame()
        {
            playerName = null;
            winPosition = false;
        }
    }
}