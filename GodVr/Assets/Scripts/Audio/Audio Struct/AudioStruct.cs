using UnityEngine;
using System;

[Serializable]
public struct AudioStruct
{
    public AudioClip clip;
    public AudioType type;

    public AudioStruct(AudioClip clip, AudioType type)
    {
        this.clip = clip;
        this.type = type;
    }
}
