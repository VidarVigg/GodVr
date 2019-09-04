using UnityEngine;

public class GameAudioObject : AudioObject
{

    #region Fields

    [SerializeField]
    private GameAudioType gameAudioType = GameAudioType.None;

    #endregion

    #region Properties

    public GameAudioType GameAudioType
    {
        get { return gameAudioType; }
    }

    #endregion

    #region Constructors

    private GameAudioObject() { }
    public GameAudioObject(GameAudioType gameAudioType, AudioClip audioClip)
    {

        this.gameAudioType = gameAudioType;
        base.audioClip = audioClip;

    }

    #endregion

}