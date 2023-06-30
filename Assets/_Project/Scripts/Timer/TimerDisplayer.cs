using System;
using TMPro;
using UnityEngine;

namespace Radgar.Timer
{
    public class TimerDisplayer : MonoBehaviour
    {
        private Timer _timer;
        [SerializeField] private TextMeshProUGUI _timerText;

        private void Awake()
        {
            _timer = GetComponent<Radgar.Timer.Timer>();
        }

        private void FixedUpdate()
        {
            DisplayTime();
        }

        private void DisplayTime()
        {
            if (_timerText)
            {
                float minutes = Mathf.FloorToInt(_timer._currentTime / 60);
                float seconds = Mathf.FloorToInt(_timer._currentTime % 60);
                _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }
}