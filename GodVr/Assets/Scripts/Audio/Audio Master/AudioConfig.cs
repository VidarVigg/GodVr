using System;
using UnityEngine;

[Serializable]
public class AudioConfig
{
    #region Fields

    [SerializeField] private AudioStruct[] audioStructs = new AudioStruct[0];

    #endregion

    #region Properties

    public AudioStruct[] AudioStructs
    {
        get { return audioStructs; }
    }

    #endregion

}