using UnityEngine;

public class HousingMaster : StructureMaster
{

    #region Fields

    [SerializeField] private HousingConfig housingConfig = null;
    [SerializeField] private HousingData housingData = null;
    [SerializeField] private HousingController housingController = null;

    #endregion

    #region Methods

    protected override void Awake()
    {
        base.Awake();
        housingController = new HousingController(this, housingConfig, housingData);
    }

    private void Start()
    {
        ServiceLocator.SessionMasterService.Population++;
    }

    public override void Grab(Controller123 controller, Rigidbody attach)
    {
        base.Grab(controller, attach);
        transform.tag = "Untagged";
    }
    public override bool Place(Controller123 stuff, Vector3 placePosition, Quaternion placeRotation)
    {
        bool result = base.Place(stuff, placePosition, placeRotation);
        if(result)
        {
            transform.tag = "House";
        }
        return result;
    }
    #endregion

}