using System;
using UnityEngine;
using ManagersAndControllers;
using ManagersAndControllers.Audio;

namespace Radgar.Timer
{
    public class Timer : MonoBehaviour
    {
        public float _currentTime;
        [SerializeField] private bool _gameIsStarted;
        [SerializeField] private Transform _hole;
        [SerializeField] private float _addToHole = 0.1f;

        private void Awake()
        {
            //EventManager.instance._startGame.AddListener(SetCurrentTime);
            EventManager.instance._startGame.AddListener(StartTime);
            EventManager.instance._startGame.AddListener(ResetHoleScale);
            EventManager.instance._endGame.AddListener(StopTime);
            EventManager.instance._impactOnTime.AddListener(SecondImpact);
            EventManager.instance._winGame.AddListener(SetPlayerTimeAsScore);
        }

        private void FixedUpdate()
        {
            UseTimer();
        }

        public void SetCurrentTime(int time)
        {
            _currentTime = time * 60;
        }

        public void StartTime()
        {
            _gameIsStarted = true;
        }

        public void StopTime()
        {
            _gameIsStarted = false;
        }

        private void UseTimer()
        {
            if (!GameManager.instance.gameIsEnded && _gameIsStarted)
            {
                if (_currentTime > 0)
                {
                    _currentTime -= Time.deltaTime;
                    _hole.localScale = new Vector3(_hole.localScale.x + _addToHole,
                        _hole.localScale.y + _addToHole, _hole.localScale.z + _addToHole);

                }
                else
                {
                    GameManager.instance.gameIsEnded = true;
                    _gameIsStarted = false;
                    EventManager.instance.EndGame();
                    AudioManager.instance.PlaySfxAudio(0);
                }
            }
        }

        private void SecondImpact(float seconds)
        {
            _currentTime -= seconds;
        }

        public void SetPlayerTimeAsScore()
        {
            StopTime();
            GameManager.instance.playerTime = (int)_currentTime;
        }

        private void ResetHoleScale()
        {
            _hole.localScale = new Vector3(1, 1, 1);
        }
    }
}