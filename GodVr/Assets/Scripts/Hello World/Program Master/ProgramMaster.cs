﻿using UnityEngine;

public class ProgramMaster : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private ProgramConfig programConfig = null;

    [SerializeField]
    private ProgramData programData = null;

    private ProgramController programController = null;

    #endregion

    #region Methods

    private void Awake()
    {
        programController = new ProgramController(this, programConfig, ref programData);
        Initialize();
        GameMaster gm = Instantiate(programConfig.GameMaster);
        ServiceLocator.GameMasterService = gm;

    }

    private void Initialize()
    {
        ServiceLocator.Iniitalize();
        SpawnGameMaster();
        SpawnAudioMaster();
    }

    private void SpawnGameMaster()
    {
        programData.GameMaster = (GameMaster)programController.Spawn(programConfig.GameMaster);
    }

    private void SpawnAudioMaster()
    {
        programData.AudioMaster = (AudioMaster)programController.Spawn(programConfig.AudioMaster);
    }

    #endregion


}