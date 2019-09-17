using UnityEngine;

public class NullSpawnMaster : ISpawnMasterService
{
    public void RegisterDeath()
    {
        Debug.Log("I am a null spawn provider");
    }
}
     