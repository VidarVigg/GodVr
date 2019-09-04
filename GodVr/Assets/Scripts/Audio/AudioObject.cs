﻿using System;
using UnityEngine;

[Serializable]
public struct AudioObject
{

    #region Fields

    [SerializeField]
    AudioType audioType;

    [SerializeField]
    private AudioClip audioClip;

    #endregion

    #region Constructors

    public AudioObject(AudioType audioType, AudioClip audioClip)
    {
        this.audioType = audioType;
        this.audioClip = audioClip;
    }

    #endregion


    #region Properties

    public AudioType AudioType { get { return audioType; } }

    public AudioClip AudioClip { get { return audioClip; } }

    #endregion

}