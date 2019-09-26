using UnityEngine;
using System;

[Serializable]
public struct AudioStruct
{
    public AudioClip[] clip;
    public AudioType type;
    public AudioSource musicAudioSource;

    [Range(0, 1)]
    public float volume;

    public AudioStruct(AudioClip[] clip, AudioType type, float volume, AudioSource musicAudioSource)
    {
        this.clip = clip;
        this.type = type;
        this.volume = volume;
        this.musicAudioSource = musicAudioSource;
    }
}
