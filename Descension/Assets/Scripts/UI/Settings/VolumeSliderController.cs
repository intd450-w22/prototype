﻿using System;
using Managers;
using UnityEngine;

namespace UI.Settings
{
    public class VolumeSliderController : MonoBehaviour
    {
        public enum VolumeType
        {
            BackgroundVolume,
            EffectVolume,
            MusicVolume
        }

        [SerializeField] private VolumeType _volumeType;

        public void OnSliderChanged(float value)
        {
            switch (_volumeType)
            {
                case VolumeType.BackgroundVolume:
                    SoundManager.SetBackgroundVolume(value);
                    return;
                case VolumeType.EffectVolume:
                    SoundManager.SetEffectVolume(value);
                    return;
                case VolumeType.MusicVolume:
                    SoundManager.SetMusicVolume(value);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}