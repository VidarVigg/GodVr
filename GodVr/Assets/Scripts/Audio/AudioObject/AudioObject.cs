using System;
using UnityEngine;

[Serializable]
public abstract class AudioObject
{

    #region Fields

    [SerializeField]
    protected AudioClip audioClip;

    #endregion

    #region Properties

    public AudioClip AudioClip { get { return audioClip; } }

    #endregion

}