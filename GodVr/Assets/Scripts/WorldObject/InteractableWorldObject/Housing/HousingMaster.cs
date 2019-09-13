using UnityEngine;

public class HousingMaster : Structure, IDamagable
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

    public void Receive(ulong damage)
    {
        
        Debug.Log("<b> Housing took " + damage + " damage</b>", gameObject);
    }

    #endregion

}