using System;
using Radgar.Difficulty;
using UnityEngine;
using Random = UnityEngine.Random;


namespace ManagersAndControllers.Spawner
{
    public class GameSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _coin;
        [SerializeField] private float percentageNumberOfObjects;

        [SerializeField] private Radgar.Timer.Timer _timer;
        public Difficulty _difficulty;

        [Header("Boundary")] 
        [SerializeField] private Vector2 boundary;

        private void Awake()
        {
            SetScreenPos();
            //EventManager.instance._startGame.AddListener(SpawnPlayer);
            //EventManager.instance._startGame.AddListener(SpawnAdditionalObjects);
        }

        public void ClearObjectsPosAndStatus()
        {
            ObjectPooling.ObjectPooling.instance.ResetPool();
        }

        public void SpawnObjectInArena()
        {
            SetTime();
            SpawnPlayer();
            SpawnCoin();
            SpawnAdditionalObjects();
        }

        private void SpawnPlayer()
        {
            _player.SetActive(true);
            
            float positionX = Random.Range(-boundary.x, boundary.x);
            float positionY = Random.Range(-boundary.y, boundary.y);

            _player.transform.position = new Vector3(positionY, positionX, 0);
        }

        private void SpawnCoin()
        {
            _coin.SetActive(true);
            
            float positionX = Random.Range(-boundary.x, boundary.x);
            float positionY = Random.Range(-boundary.y, boundary.y);

            _coin.transform.position = new Vector3(positionY, positionX, 0);
        }

        private void SpawnAdditionalObjects()
        {
            for (int i = 0; i < _difficulty.numberOfFish; i++)
            {
                float positionX = Random.Range(-boundary.x, boundary.x);
                float positionY = Random.Range(-boundary.y, boundary.y);
                
                GameObject temp = ObjectPooling.ObjectPooling.instance.GetPooledObject();
                temp.SetActive(true);
                temp.transform.position = new Vector3(positionY, positionX, 0);
            }
        }

        private void SetScreenPos()
        {
            boundary.x = Camera.main.orthographicSize;
            boundary.y = boundary.x * Camera.main.aspect;
        }
        
        private void SetTime(){_timer.SetCurrentTime(_difficulty.timeGameEnd);}
        
    }
}