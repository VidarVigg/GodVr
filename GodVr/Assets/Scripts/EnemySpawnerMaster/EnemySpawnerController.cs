using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController
{

    #region Fields

    private EnemySpawnerConfig enemySpawnerConfig = null;

    private EnemySpawnerData enemySpawnerData = null;

    private EnemySpawnerMaster enemySpawnerMaster = null;

    #endregion

    #region Constructors

    private EnemySpawnerController() { }
    public EnemySpawnerController(EnemySpawnerMaster enemySpawnerMaster, EnemySpawnerConfig enemySpawnerConfig, EnemySpawnerData enemySpawnerData)
    {
        this.enemySpawnerMaster = enemySpawnerMaster;
        this.enemySpawnerConfig = enemySpawnerConfig;
        this.enemySpawnerData = enemySpawnerData;
    }

    #endregion

    #region Methods

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        for (int i = 0; i <= enemySpawnerConfig.SpawnAmount; i++)
        {
            for (int j = 0; j <= enemySpawnerConfig.SpawnAmount; j++)
            {
                enemySpawnerConfig.EnemyClone = GameObject.Instantiate(enemySpawnerConfig.EnemyPrefab, enemySpawnerConfig.SpawnPos.position + (new Vector3((float)i / 2, 0, (float)j / 2)), Quaternion.identity);
            }
        }
    }

    #endregion

}