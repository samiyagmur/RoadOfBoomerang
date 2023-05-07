using Script.Signals;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private List<AudioClip> audioClipsList;

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
            AudioSignals.Instance.onUpdateSoundVolume += OnUpdateSoundVolume;
            AudioSignals.Instance.onUpdateSoundStatus += OnUpdateSoundStatus;
        }

        private void UnsubscribeEvents()
        {
            AudioSignals.Instance.onUpdateSoundVolume -= OnUpdateSoundVolume;
            AudioSignals.Instance.onUpdateSoundVolume -= OnUpdateSoundVolume;

        }

        private void OnDisable() => UnsubscribeEvents();
        private void OnUpdateSoundStatus(bool status)
        {
            audioSource.mute = status;
        }

        private void OnUpdateSoundVolume(float volume)
        {
            audioSource.volume = volume;
        }


    }
}