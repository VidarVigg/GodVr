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
    private Transform[] spawnPoints = new Transform[0];

    [SerializeField]
    private float howOftenShouldEnemiesSpawn;

    [SerializeField]
    private int howManyWavesAreAllowed;

    [SerializeField]
    private static int waveAmt;

    [SerializeField]
    private int wavesInGame;

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
    

    public SpawnStruct[] SpawnStructs
    {
        get { return spawnStructs; }
        set { spawnStructs = value; }
    }

    public Transform[] SpawnPoints
    {
        get { return spawnPoints; }
        set { spawnPoints = value; }
    }

    public float HowOftenShouldEnemiesSpawn
    {
        get { return howOftenShouldEnemiesSpawn; }
        set { howOftenShouldEnemiesSpawn = value; }
    }

    public int WaveAmt
    {
        get { return waveAmt; }
        set
        {
            wavesInGame = value;
            waveAmt = value;
        }
    }

    public int HowManyWavesAreAllowed
    {
        get { return howManyWavesAreAllowed; }
        set { howManyWavesAreAllowed = value; }
    }



    #endregion

}