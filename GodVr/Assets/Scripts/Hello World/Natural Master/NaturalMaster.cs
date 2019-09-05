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

    protected override void Setup()
    {
        base.Setup();
        naturalController = new NaturalController(this, naturalConfig, naturalData);
    }

    private void Update()
    {
        naturalController.Update();
    }

    #endregion

}