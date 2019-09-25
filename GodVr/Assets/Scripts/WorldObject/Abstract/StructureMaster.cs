using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StructureMaster : InteractableWorldObject, IDamagable
{
    #region Fields

    [SerializeField]
    protected ResourceStruct[] resourceCosts = null;

    [SerializeField]
    protected Vector3 scale = Vector3.zero;

    [SerializeField]
    protected StructureConfig structureConfig = null;

    [SerializeField]
    protected StructureData structureData = null;

    [SerializeField]
    protected StructureController structureController = null;


    #endregion


    #region Methods


    protected override void Awake()
    {
        base.Awake();
        structureController = new StructureController(this, structureConfig, structureData);
    }  

    public void Receive(long damage)
    {
        structureController.RecieveDamage(damage);
        ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXHouseDamage, audioSource);
    }
    public void DestroyHouse()
    {
        if (joint == null)
        {
            ServiceLocator.SessionMasterService.Population--;

            if (!structureData.Triggered)
            {
                structureData.Triggered = true;
                GameObject clone = Object2.Instantiate(structureConfig.DestroyFX);
                Destroy(clone, 2);
                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        ServiceLocator.SessionMasterService.Population--;
    }
    #endregion

}