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
        if (Input.GetKeyDown(KeyCode.L))
        {
            FindObjectOfType<UnitMaster>().Receive(1337);
        }
    }

    public void RegisterDeath()
    {
        if (enemySpawnerData.LastWave != 0)
        {
            if (enemySpawnerData.LastWave > 0)
            {
                enemySpawnerData.LastWave--;
                if (enemySpawnerData.LastWave == 0)
                {

                    enemySpawnerConfig.WaveAmt--;
                }
            }
        }
    }

}