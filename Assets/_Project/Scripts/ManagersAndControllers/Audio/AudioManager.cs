using System;
using Radgar.Singleton;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ManagersAndControllers.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioSource _mainAudio;
        [SerializeField] private AudioSource _sfxAudio;

        [SerializeField] private AudioClip[] _mainAudioClips;
        [SerializeField] private AudioClip[] _sfxAudioClips;

        private void Start()
        {
            int id = Random.Range(0, _mainAudioClips.Length);
            PlayMainAudioClip(id);
        }


        private void PlayMainAudioClip(int id)
        {
            _mainAudio.clip = _mainAudioClips[id];
            _mainAudio.Play();
        }

        public void PlaySfxAudio(int id)
        {
            _sfxAudio.clip = _sfxAudioClips[id];
            _sfxAudio.Play();
        }
    }
}