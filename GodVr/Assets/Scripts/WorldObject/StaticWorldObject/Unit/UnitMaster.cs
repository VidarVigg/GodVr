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
            else if (collider.CompareTag("ImpactZone"))
            {
                Debug.Log("I'm in the impact zone!");
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
        // the wise man bowed his head solemnly and spoke: "theres actually zero difference between good & bad things. you imbecile. you fucking moron"
        RaycastHit hitInfo;
        LayerMask mask = LayerMask.GetMask("Terrain");
        Physics.Raycast(transform.position + Vector3.up * 10, Vector3.down, out hitInfo, 50.0f, mask);
        var point = hitInfo.point;

        UnityEngine.Debug.Log("ded af xd");
        ServiceLocator.SpawnerMasterService.RegisterDeath();

        GameObject newBoi = Instantiate(unitConfig.FlyingCorpse, point, Quaternion.identity);
        //Debug.Log(transform.position);
        newBoi.SetActive(true);
        Destroy(gameObject);
    }


    #endregion

}