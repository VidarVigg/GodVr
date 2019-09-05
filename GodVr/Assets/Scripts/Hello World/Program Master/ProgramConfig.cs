using System;
using UnityEngine;

[Serializable]
public class ProgramConfig
{

    #region Fields

    [SerializeField]
    private GameMaster gameMaster = null;

    [SerializeField]
    private AudioMaster audioMaster = null;

    #endregion

    #region Properties

    public GameMaster GameMaster
    {
        get { return gameMaster; }
    }

    public AudioMaster AudioMaster
    {
        get { return audioMaster; }
    }

    #endregion

}
