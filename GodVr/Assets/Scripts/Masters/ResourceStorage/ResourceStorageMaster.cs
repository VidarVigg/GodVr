using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStorageMaster : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private ResourceStorageConfig resourceStorageConfig = null;

    [SerializeField]
    private ResourceStorageData resourceStorageData = null;

    private ResourceStorageController resourceStorageController = null;

    #endregion

    #region Properties



    #endregion

    #region Methods

    private void Awake()
    {
        resourceStorageController = new ResourceStorageController(this, resourceStorageConfig, resourceStorageData);
    }

    private void Update()
    {
        resourceStorageController.Update();
    }

    #endregion



}
