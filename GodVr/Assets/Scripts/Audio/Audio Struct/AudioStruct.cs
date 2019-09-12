using UnityEngine;
using System;

[Serializable]
public struct AudioStruct
{
    public AudioClip clip;
    public AudioType type;
    public GameObject go;

    public AudioStruct(AudioClip clip, AudioType type, GameObject go)
    {
        this.clip = clip;
        this.type = type;
        this.go = go;
    }
}
