using System;
using UnityEngine;

[Serializable]
public struct ResourceStruct
{
    [SerializeField]
    private ResourceType resource;

    [SerializeField]
    private int value;

    public ResourceType Resource
    {
        get { return resource; }
    }
    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public ResourceStruct(int value, ResourceType resource)
    {
        this.value = value;
        this.resource = resource;
    }
}

