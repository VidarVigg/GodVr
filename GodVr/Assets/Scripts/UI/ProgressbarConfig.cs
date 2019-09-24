using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class ProgressbarConfig
{

    #region Fields

    [SerializeField]
    private Image foreground = null;

    [SerializeField]
    private Image background = null;

    [SerializeField]
    private Image outline = null;

    [SerializeField]
    private TextMeshProUGUI text = null;

    #endregion

    #region Properties

    public Image Foreground
    {
        get { return foreground; }
    }

    public Image Background
    {
        get { return background; }
    }

    public Image Outline
    {
        get { return outline; }
    }

    public TextMeshProUGUI Text
    {
        get { return text; }
    }

    #endregion

}
