using System;
using UnityEngine;

[Serializable]
public class InputConfig
{

    #region Fields

    [SerializeField]
    private KeyCode helloWorld = KeyCode.None;
    public KeyCode HelloWorld
    {
        get { return helloWorld; }
    }

    #endregion

}