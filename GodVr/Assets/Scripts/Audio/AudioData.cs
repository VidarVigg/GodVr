using System;
using UnityEngine;

[Serializable]
public class AudioData
{

    #region Fields

    [SerializeField] private AudioObject[] audioObjectsMenu = new AudioObject[0];
    [SerializeField] private AudioObject[] audioObjectsGame = new AudioObject[0];


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