using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramMaster : MonoBehaviour
{

    [SerializeField]
    private ProgramConfig programConfig = null;

    [SerializeField]
    private ProgramData programData = null;

    private ProgramController programController = null;

    private void Awake()
    {
        programController = new ProgramController(this, programConfig, programData);
        Initialize();
        GameMaster gm = Instantiate(programConfig.GameMaster);
        ServiceLocator.GameMasterService = gm;

    }

    private void Initialize()
    {
        ServiceLocator.Iniitalize();
        SpawnGameMaster();
    }

    private void SpawnGameMaster()
    {
        programController.Spawn(programConfig.GameMaster, programData.GameMaster);
    }

}
