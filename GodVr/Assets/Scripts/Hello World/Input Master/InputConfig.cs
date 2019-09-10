using System;
using UnityEngine;

[Serializable]
public class InputConfig
{

    #region Fields

    [SerializeField]
    private int inputLength = 0;

    #endregion

    #region Properties

    public int InputLength
    {
        get { return inputLength; }
    }

    #endregion

}