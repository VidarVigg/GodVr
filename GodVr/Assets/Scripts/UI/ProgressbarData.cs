using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ProgressbarData
{

    #region Fields

    [SerializeField]
    private float value = 0;

    [SerializeField]
    private float maxValue = 100;

    #endregion

    #region Properties

    public float Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public float MaxValue
    {
        get { return maxValue; }
        set { this.value = value; }
    }

    #endregion

}