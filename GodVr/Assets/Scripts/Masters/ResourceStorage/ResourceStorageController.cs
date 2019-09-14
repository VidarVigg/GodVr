using System;

internal class ResourceStorageController
{
    
    private ResourceStorageMaster resourceStorageMaster;
    private ResourceStorageConfig resourceStorageConfig;
    private ResourceStorageData resourceStorageData;

    private ResourceStorageController(){}

    public ResourceStorageController(ResourceStorageMaster resourceStorageMaster, ResourceStorageConfig resourceStorageConfig, ResourceStorageData resourceStorageData)
    {
        this.resourceStorageMaster = resourceStorageMaster;
        this.resourceStorageConfig = resourceStorageConfig;
        this.resourceStorageData = resourceStorageData;
    }

    public bool AddResource(ResourceType resource,int value)
    {
        if (resource == ResourceType.None)
            return false;

        if (value < 0)
        {
            UnityEngine.Debug.Log("Value needs to be a positive value not negative ( value = " + value + ")");
            return false;
        }

        for (int i = 0; i < resourceStorageData.Storage.Length; i++)
        {
            if(resourceStorageData.Storage[i].Resource == resource)
            {
                if (resourceStorageData.Storage[i].Value > resourceStorageConfig.ResourceCap)
                {
                    UnityEngine.Debug.Log("You have to much! Spend some of " + resource);
                    return false;
                }
                resourceStorageData.Storage[i].Value += value;
                return true;
            }
        }
        UnityEngine.Debug.Log("Did not find "+ resource +" as a storagable resource");
        return false;
    }
    public bool SpendResource(ResourceType resource, int value)
    {
        if (resource == ResourceType.None)
        {
            return false;
        }
        if (value < 0)
        {
            UnityEngine.Debug.Log("Value needs to be a positive value not negative ( value = " + value + ")");
            return false;
        }


        for (int i = 0; i < resourceStorageData.Storage.Length; i++)
        {
            if (resourceStorageData.Storage[i].Resource == resource)
            {
                if(resourceStorageData.Storage[i].Value - value < 0)
                {
                    UnityEngine.Debug.Log("Need "+ -(resourceStorageData.Storage[i].Value - value) + " more " + resource);
                    return false;
                }
                resourceStorageData.Storage[i].Value -= value;
                return true;
            }
        }
        UnityEngine.Debug.Log("Did not find that resource as a storagable resource");
        return false;
    }

    internal void Update()
    {
        //throw new NotImplementedException();
    }
}