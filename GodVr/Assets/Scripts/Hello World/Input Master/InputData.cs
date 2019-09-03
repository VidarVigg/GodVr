using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class InputData
{

    #region Fields

    [SerializeField]
    private KeyCode helloWorld = KeyCode.None;

    [SerializeField]
    private BitArray inputs = null;

    #endregion

    #region Properties

    public KeyCode HelloWorld
    {
        get { return helloWorld; }
        set { helloWorld = value; }
    }

    public BitArray Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }

    #endregion

}