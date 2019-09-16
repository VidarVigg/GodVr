using UnityEngine;

public class UnitMaster : StaticWorldObject
{

    #region Fields

    [SerializeField]
    private UnitConfig unitConfig = null;

    [SerializeField]
    private UnitData unitData = null;

    private UnitController unitController = null;

    #endregion

    #region Properties



    #endregion

    #region Methods

    protected virtual void Awake()
    {
        unitController = new UnitController(this, unitConfig, unitData);
    }

    protected override void OnCollision(Collision collision)
    {
        base.OnCollision(collision);
        Debug.Log("hit");

        if (collision.gameObject.GetComponent<Rock>())// temp Code
        {
            Debug.Log("Interactable Object hit actor ", collision.gameObject);
        }
        // Kolla velocity på den andra objectet
        // Sen kör får vi hämta från objectet som kolliderade med oss dens damage.
        // Sen ta och ge skadan på MIG. 

    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Debug.Log("hesfhe");
    }

    #endregion

}