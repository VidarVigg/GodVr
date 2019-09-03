using System;
using UnityEngine;

[Serializable]
public class InputData
{

    #region Fields

    [SerializeField]
    private KeyCode helloWorld = KeyCode.None;

    #endregion

    #region Properties

    public KeyCode HelloWorld
    {
        get { return helloWorld; }
        set { helloWorld = value; }
    }

    #endregion

}