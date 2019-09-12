﻿using UnityEngine;

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
            unitAIConfig.NavMeshAgent.SetDestination(unitAIData.Destination);
        }

    }

    private void Initialize()
    {
        unitAIData.Hits = new Collider[unitAIConfig.MaxHits];
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
        unitAIData.Destination = unitAIData.Hits[nearest].transform.position;
        return true;

    }

    #endregion

}