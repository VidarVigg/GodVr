using UnityEngine;

public class UnitAIController
{

    #region Fields

    private UnitAIMaster unitAIMaster = null;

    [SerializeField]
    private UnitAIConfig unitAIConfig = null;

    [SerializeField]
    private UnitAIData unitAIData = null;

    #endregion

    #region Constructors

    private UnitAIController() { }
    public UnitAIController(UnitAIMaster unitAIMaster, UnitAIConfig unitAIConfig, UnitAIData unitAIData)
    {

        this.unitAIMaster = unitAIMaster;
        this.unitAIConfig = unitAIConfig;
        this.unitAIData = unitAIData;

        Initialize();

    }

    #endregion

    #region Methods

    public void Update()
    {

        if (SearchForStructure())
        {

            unitAIData.Animator.SetBool("Running", true);
            if ((unitAIData.Tick += Time.deltaTime) >= unitAIData.DamageFrequency)
            {
                unitAIData.Tick -= unitAIData.DamageFrequency;
                DamageBuilding();

            }

        }
        else
        {
            unitAIData.Target = null;
            unitAIData.Destination = unitAIMaster.transform.position;
            unitAIData.Animator.SetBool("Running", false);
            unitAIData.Animator.SetBool("Attacking", false);
            
        }
            unitAIConfig.NavMeshAgent.SetDestination(unitAIData.Destination);


    }

    private void Initialize()
    {
        unitAIData.Hits = new Collider[unitAIConfig.MaxHits];
        unitAIData.Animator = unitAIMaster.GetComponent<Animator>();
    }

    private bool SearchForStructure()
    {

        int count = Physics.OverlapSphereNonAlloc(unitAIMaster.transform.position, unitAIData.SphereCastRadius, unitAIData.Hits, unitAIConfig.LayerMask);

        if (count < 1)
        {
            return false;
        }

        int start = -1;

        for (int i = 0; i < count; i++)
        {

            if (!unitAIData.Hits[i].transform.CompareTag("House"))
            {
                continue;
            }

            start = i;
            break;

        }

        if (start < 0)
        {
            return false;
        }

        int nearest = start;

        for (int i = start + 1; i < count; i++)
        {

            if (!unitAIData.Hits[i].transform.CompareTag("House"))
            {
                continue;
            }

            if (Vector3.Distance(unitAIMaster.transform.position, unitAIData.Hits[nearest].transform.position) < Vector3.Distance(unitAIMaster.transform.position, unitAIData.Hits[i].transform.position))
            {
                continue;
            }

            nearest = i;

        }


        unitAIData.Target = unitAIData.Hits[nearest].GetComponent<HousingMaster>();
        unitAIData.Destination = unitAIData.Hits[nearest].transform.position;

        return true;

    }

    private void DamageBuilding()
    {
        Vector3 temp = unitAIData.Target.transform.position;

        if ((temp - unitAIMaster.gameObject.transform.position).magnitude < 1f)
        {
            (unitAIData.Target as IDamagable).Receive(1);
            unitAIData.Animator.SetBool("Attacking", true);
        }


    }
    
    
    #endregion

}