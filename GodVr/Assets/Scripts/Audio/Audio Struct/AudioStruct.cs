using UnityEngine;
using System;

[Serializable]
public struct AudioStruct
{
    public AudioClip[] clip;
    public AudioType type;
    [Range(0, 1)]
    public float volume;

    public AudioStruct(AudioClip[] clip, AudioType type, float volume)
    {
        this.clip = clip;
        this.type = type;
        this.volume = volume;
    }
}
