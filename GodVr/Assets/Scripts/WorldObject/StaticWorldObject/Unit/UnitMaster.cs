using UnityEngine;

public class UnitMaster : StaticWorldObject, IDamagable
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

    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);
        if (collider.gameObject.layer == 9)
        {
            if (collider.attachedRigidbody.velocity.sqrMagnitude > 0.05)
            {
                Debug.Log("Interactable Hit us");
                Receive(long.MaxValue);
            }
            
        }

    }

    public void Receive(long damage)
    {
        Debug.Log(damage + " damage");
        unitController.RecieveDamage(damage);
    }

    public void KillUnit()
    {
        UnityEngine.Debug.Log("ded af xd");
        ServiceLocator.SpawnerMasterService.RegisterDeath();

        GameObject newBoi = Instantiate(unitConfig.FlyingCorpse, transform.position, Quaternion.identity);
        newBoi.SetActive(true);
        Destroy(gameObject);
    }

    //private void Update()
    //{
    //    if (Input.anyKeyDown)
    //    {
    //        KillUnit();
    //    }
    //}

    #endregion

}