using Assets.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Application.Services
{
    public class GameAudioManager : IGameAudioManager
    {
        private AudioSource _audioSource;

        public GameAudioManager(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void PlayBackgroundAudio()
        {
            if (_audioSource != null)
            {
                _audioSource.loop = true;  // Loop the music
                _audioSource.volume = 0.25f; // Set the volume to 25%
                _audioSource.Play(); // Start playing background music
            }
        }

        public void StopBackgroundAudio()
        {
            _audioSource.Stop();
        }
    }
}
