using System;
using AI;
using ManagersAndControllers;
using ManagersAndControllers.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Interectable
{
    [RequireComponent(typeof(FishAI))]
    public class Fish : Interectable
    {
        public GameObject[] _fishType;

        private void OnEnable()
        {
            foreach (var fish in _fishType)
            {
                fish.SetActive(false);
            }

            int id = Random.Range(0, _fishType.Length);
            _fishType[id].SetActive(true);
        }

        public override void Interact()
        {
            gameObject.SetActive(false);
            AudioManager.instance.PlaySfxAudio(2);
            base.Interact();
        }
    }
}