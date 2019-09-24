using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressbarMaster : MonoBehaviour
{

    #region Fields

    [Header("Config"), SerializeField]
    private ProgressbarConfig progressbarConfig = null;

    [Header("Data"), SerializeField]
    private ProgressbarData progressbarData = null;

    private ProgressbarController progressbarController = null;

    #endregion

    #region Methods

    private void Awake()
    {
        progressbarController = new ProgressbarController(this, progressbarConfig, progressbarData);
    }

    public void SetValue(float value)
    {
        progressbarController.SetValue(value);
    }

    #endregion

}