using UnityEngine;

public class NaturalMaster : InteractableWorldObject
{

    #region Fields

    [SerializeField]
    private NaturalConfig naturalConfig = null;

    [SerializeField]
    private NaturalData naturalData = null;

    private NaturalController naturalController = null;

    #endregion

    #region Properties



    #endregion

    #region Methods

    protected override void Awake()
    {
        base.Awake();
        naturalController = new NaturalController(this, naturalConfig, naturalData);
    }

    protected override void Update()
    {
        base.Update();
        naturalController.Update();
    }

    #endregion

}