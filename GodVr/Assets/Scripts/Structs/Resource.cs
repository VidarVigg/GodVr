using System;
using UnityEngine;

[Serializable]
public struct Resource
{

    #region Fields

    [SerializeField]
    private ResourceType type;

    [SerializeField]
    private float amount;

    #endregion

    #region Properties

    public ResourceType Type
    {
        get { return type; }
    }
    public float Amount
    {
        get { return amount; }
        set { amount = value; }
        //todo: validate set
    }

    #endregion

    #region Constructors

    public Resource(ResourceType type, float amount)
    {
        this.type = type;
        this.amount = amount;
    }

    #endregion

}