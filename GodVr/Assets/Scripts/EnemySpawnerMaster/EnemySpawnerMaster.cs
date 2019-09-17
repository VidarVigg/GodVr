using UnityEngine;

public class EnemySpawnerMaster : MonoBehaviour, ISpawnMasterService
{

    #region Fields

    [SerializeField]
    private EnemySpawnerConfig enemySpawnerConfig = null;

    [SerializeField]
    private EnemySpawnerData enemySpawnerData = null;

    private EnemySpawnerController enemySpawnerController = null;

    #endregion

    private void Awake()
    {
        enemySpawnerController = new EnemySpawnerController(this, enemySpawnerConfig, enemySpawnerData);
    }

    void Update()
    {
        enemySpawnerController.Update();
    }

    public void RegisterDeath()
    {
        enemySpawnerData.SpawnInstances--;
    }

}