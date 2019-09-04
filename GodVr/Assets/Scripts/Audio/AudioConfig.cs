using UnityEngine;
using System;

[Serializable]
public class AudioConfig
{
    #region Fields

    [SerializeField] private MenuAudioSet menuAudioDefault;
    [SerializeField] private GameAudioSet gameAudioDefault;

    #endregion

    #region Properties

    public MenuAudioSet MenuAudioSet { get { return menuAudioDefault; } }
    public GameAudioSet GameAudioSet { get { return gameAudioDefault; } }

    #endregion
}