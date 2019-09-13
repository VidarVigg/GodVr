using System;
using UnityEngine.AI;
using UnityEngine;


[Serializable]
public class UnitAIConfig 
{

    #region Fields

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private int maxHits;

    [SerializeField]
    private float stopDistance;

    #endregion

    #region Properties

    public NavMeshAgent NavMeshAgent
    {
        get { return agent; }
        set { agent = value; }
    }

    public LayerMask LayerMask
    {
        get { return layerMask; }
        set { layerMask = value; }
    }

    public int MaxHits
    {
        get { return maxHits; }
        set { maxHits = value; }
    }

    public float StopDistance
    {
        get { return stopDistance; }
        set { stopDistance = value; }
    }

    #endregion

}