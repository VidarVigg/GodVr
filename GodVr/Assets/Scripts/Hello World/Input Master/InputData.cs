using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class InputData
{

    #region Fields

    [SerializeField]
    private BitArray rightBitArray = null;

    [SerializeField]
    private BitArray leftBitArray = null;

    #endregion

    #region Properties

    public BitArray RightBitArray
    {
        get { return rightBitArray; }
        set { rightBitArray = value; }
    }

    public BitArray LeftBitArray
    {
        get { return leftBitArray; }
        set { leftBitArray = value; }
    }

    #endregion

}