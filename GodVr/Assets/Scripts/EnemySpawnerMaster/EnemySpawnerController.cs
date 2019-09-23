using System.Collections;
using System.Collections.Generic;
using System;
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

    System.Random random = new System.Random();

    public void Update()
    {

        if ((enemySpawnerData.CurrentTime += Time.deltaTime) >= enemySpawnerConfig.HowOftenShouldEnemiesSpawn)
        {
            enemySpawnerData.CurrentTime -= enemySpawnerConfig.HowOftenShouldEnemiesSpawn;

            if (enemySpawnerConfig.WaveAmt < enemySpawnerConfig.HowManyWavesAreAllowed)
            {
                Spawn(new SpawnStruct[] { enemySpawnerConfig.SpawnStructs[random.Next(0, enemySpawnerConfig.SpawnStructs.Length)] });
            }
        }
    }

    private void Spawn(SpawnStruct[] spawnStruct)
    {
        int rand = UnityEngine.Random.Range(0, enemySpawnerConfig.SpawnPoints.Length);
        enemySpawnerConfig.WaveAmt++;

        if (enemySpawnerConfig.WaveAmt <= enemySpawnerConfig.HowManyWavesAreAllowed)
        {
            for (int i = 0; i < spawnStruct.Length; i++)
            {
                for (int j = 0; j < spawnStruct[i].rows; j++)
                {

                    for (int k = 0; k < spawnStruct[i].columns; k++)
                    {

                        enemySpawnerConfig.EnemyClone = Object2.Instantiate(enemySpawnerConfig.EnemyPrefab, 
                        enemySpawnerConfig.SpawnPoints[rand].position + (new Vector3((float)k / 2, 0, (float)j / 2)), 
                        Quaternion.identity);

                        enemySpawnerData.LastWave = spawnStruct[i].rows * spawnStruct[i].columns;
                        
                    }
                }
            }

        }
    }

    #endregion

}

[System.Serializable]
public struct SpawnStruct
{
    public int rows;
    public int columns;

    public SpawnStruct(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
    }

}