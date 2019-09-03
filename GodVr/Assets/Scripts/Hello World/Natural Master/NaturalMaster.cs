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

    private void Awake()
    {
        naturalController = new NaturalController(this, naturalConfig, naturalData);
    }

    private void Update()
    {
        naturalController.Update();
    }

    public override void Grab()
    {

    }

    public override void Place()
    {

    }

    public override void Throw()
    {

    }

    #endregion

}