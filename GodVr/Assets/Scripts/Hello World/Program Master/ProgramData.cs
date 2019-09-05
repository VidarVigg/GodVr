using System;
using UnityEngine;

[Serializable]
public class ProgramData
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
        set { gameMaster = value; }
    }

    public AudioMaster AudioMaster
    {
        get { return audioMaster; }
        set{ audioMaster = value; }
    }

    #endregion

}