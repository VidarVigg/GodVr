﻿using System.Collections;
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
      
        if((enemySpawnerData.CurrentTime += Time.deltaTime) >= enemySpawnerData.SpawnFrequency)
        {
            enemySpawnerData.CurrentTime -= enemySpawnerData.SpawnFrequency;

            if (enemySpawnerData.SpawnInstances < enemySpawnerData.SpawnCap)
            {
                Debug.Log("Hej");
                Spawn(new SpawnStruct[] { enemySpawnerConfig.SpawnStructs[random.Next(0, enemySpawnerConfig.SpawnStructs.Length)] });
            }      
        }
    }


    //todo: Stop Spawning When Idle
    
    private void Spawn(SpawnStruct[] spawnStruct)
    {
        for (int i = 0; i < spawnStruct.Length; i++)
        {
            for (int j = 0; j < spawnStruct[i].rows; j++)
            {

                for (int k = 0; k < spawnStruct[i].columns; k++)
                {

                    enemySpawnerConfig.EnemyClone = Object2.Instantiate(enemySpawnerConfig.EnemyPrefab, enemySpawnerConfig.SpawnPoints[random.Next(0, enemySpawnerConfig.SpawnPoints.Length)].position + (new Vector3((float)k / 2 , 0, (float)j / 2)), Quaternion.identity);
                    enemySpawnerData.SpawnInstances ++;
                
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