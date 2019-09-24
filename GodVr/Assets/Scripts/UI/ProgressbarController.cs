using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressbarController
{

    #region Fields

    private ProgressbarMaster progressbarMaster = null;
    private ProgressbarConfig progressbarConfig = null;
    private ProgressbarData progressbarData = null;

    #endregion

    #region Constructors

    private ProgressbarController() { }
    public ProgressbarController(ProgressbarMaster progressbarMaster, ProgressbarConfig progressbarConfig, ProgressbarData progressbarData)
    {

        this.progressbarMaster = progressbarMaster;
        this.progressbarConfig = progressbarConfig;
        this.progressbarData = progressbarData;

        Initialize();

    }

    #endregion

    #region Methods

    private void Initialize()
    {
        SetValue(progressbarData.MaxValue);
    }

    public void SetValue(float value)
    {
        progressbarData.Value = ClampValue(value);
        SetText();
        SetSize();
    }
    private float ClampValue(float value)
    {

        if (value < 0)
        {
             return 0;
        }

        else if (value > progressbarData.MaxValue)
        {
            return  progressbarData.MaxValue;
        }

        return value;

    }
    private void SetText()
    {
        progressbarConfig.Text.text = progressbarData.Value + "/" + progressbarData.MaxValue;
    }
    private void SetSize()
    {
        progressbarConfig.Foreground.rectTransform.sizeDelta = new Vector2(-progressbarConfig.Background.rectTransform.rect.width * (1f - (progressbarData.Value / progressbarData.MaxValue)), progressbarConfig.Background.rectTransform.sizeDelta.y);
    }

    #endregion

}
