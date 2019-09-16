using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemySpawnerConfig
{
    #region Fields

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject enemyClone;

    [SerializeField]
    private Transform spawnPos;

    [SerializeField]
    private int spawnAmount;

    [SerializeField]
    private SpawnStruct[] spawnStructs = new SpawnStruct[16] 
    {

        new SpawnStruct(1, 1),
        new SpawnStruct(1, 2),
        new SpawnStruct(1, 3),
        new SpawnStruct(1, 4),
        new SpawnStruct(2, 1),
        new SpawnStruct(2, 2),
        new SpawnStruct(2, 3),
        new SpawnStruct(2, 4),
        new SpawnStruct(3, 1),
        new SpawnStruct(3, 2),
        new SpawnStruct(3, 3),
        new SpawnStruct(3, 4),
        new SpawnStruct(4, 1),
        new SpawnStruct(4, 2),
        new SpawnStruct(4, 3),
        new SpawnStruct(4, 4),

    };

    #endregion

    #region Properties

    public GameObject EnemyPrefab
    {
        get { return enemyPrefab; }
        set { enemyPrefab = value; }
    }

    public GameObject EnemyClone
    {
        get { return enemyClone; }
        set { enemyClone = value; }
    }

    public Transform SpawnPos
    {
        get { return spawnPos; }
        set { spawnPos = value; }
    }

    public int SpawnAmount
    {
        get { return spawnAmount; }
        set { spawnAmount = value; }
    }

    public SpawnStruct[] SpawnStructs
    {
        get { return spawnStructs; }
        set { spawnStructs = value; }
    }

    #endregion

}