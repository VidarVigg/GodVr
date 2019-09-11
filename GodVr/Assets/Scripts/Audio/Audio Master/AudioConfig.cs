using System;
using UnityEngine;

[Serializable]
public class AudioConfig
{
    #region Fields

    [System.Serializable]
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

    [SerializeField] private AudioStruct[] audioStructs = new AudioStruct[0]; // make properties
    #endregion

    #region Properties

    public AudioStruct[] AudioStructs
    {
        get { return audioStructs; }
    }

    #endregion

}