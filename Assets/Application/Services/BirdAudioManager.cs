using Assets.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Application.Services
{
    public class BirdAudioManager : IBirdAudioManager
    {
        private AudioSource _birdWingFlapAudioSource;
        private AudioSource _birdCrashAudioSource;

        public BirdAudioManager(AudioSource birdWingFlapAudioSource, AudioSource birdCrashAudioSource)
        {
            _birdWingFlapAudioSource = birdWingFlapAudioSource;
            _birdCrashAudioSource = birdCrashAudioSource;
        }

        public void PlayCrashAudio()
        {
            if (_birdCrashAudioSource != null)
            {
                _birdCrashAudioSource.volume = 0.80f; // Set the volume to 50%
                _birdCrashAudioSource.Play(); // Play the collision sound
            }
        }

        public void PlayWingFlapAudio()
        {
            if (_birdWingFlapAudioSource is not null)
            {
                _birdWingFlapAudioSource.volume = 1f; // Set the volume to 50%
                _birdWingFlapAudioSource.Play(); // Start playing background music
            }
        }
    }
}
