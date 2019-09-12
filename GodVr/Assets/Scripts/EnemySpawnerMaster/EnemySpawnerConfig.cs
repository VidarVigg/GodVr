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

    #endregion

}
