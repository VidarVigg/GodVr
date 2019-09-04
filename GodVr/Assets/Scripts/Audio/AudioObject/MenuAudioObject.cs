using UnityEngine;

public class MenuAudioObject : AudioObject
{

    #region Fields

    [SerializeField]
    private MenuAudioType menuAudioType = MenuAudioType.None;

    #endregion

    #region Properties

    public MenuAudioType MenuAudioType
    {
        get { return menuAudioType; }
    }

    #endregion

    #region Constructors

    private MenuAudioObject() { }
    public MenuAudioObject(MenuAudioType menuAudioType, AudioClip audioClip)
    {
        this.menuAudioType = menuAudioType;
        base.audioClip = audioClip;
    }

    #endregion

}