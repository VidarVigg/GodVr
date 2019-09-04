using System;
using UnityEngine;

[Serializable]
public class AudioConfig
{

    #region Fields

    [SerializeField]
    private MenuAudioSet menuAudioDefault = null;

    [SerializeField]
    private GameAudioSet gameAudioDefault = null;

    #endregion

    #region Properties

    public MenuAudioSet MenuAudioSet
    {
        get { return menuAudioDefault; }
    }

    public GameAudioSet GameAudioSet
    {
        get { return gameAudioDefault; }
    }

    #endregion

}