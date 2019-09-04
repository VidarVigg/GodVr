using System;
using UnityEngine;

[Serializable]
public class AudioData
{

    #region Fields

    [SerializeField] private AudioObject[] audioObjectsMenu = null;
    [SerializeField] private AudioObject[] audioObjectsGame = null;

    #endregion

    #region Properties

    public AudioObject[] AudioObjectsMenu
    {
        get { return audioObjectsMenu; }
        set { audioObjectsMenu = value; }
    }

    public AudioObject[] AudioObjectsGame
    {
        get { return audioObjectsGame; }
        set { audioObjectsGame = value; }
    }

    #endregion

}