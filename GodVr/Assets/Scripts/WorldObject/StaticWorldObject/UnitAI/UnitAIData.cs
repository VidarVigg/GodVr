using System;
using UnityEngine;

[Serializable]
public class UnitAIData
{

    #region Fields

    [SerializeField]
    private float sphereCastRadius;

    [SerializeField]
    private Collider[] hits = null;

    [SerializeField]
    private Vector3 destination = Vector3.zero;


    #endregion

    #region Properties

    public float SphereCastRadius
    {
        get { return sphereCastRadius; }
        set { sphereCastRadius = value; }
    }

    public Collider[] Hits
    {
        get { return hits; }
        set { hits = value; }
    }

    public Vector3 Destination
    {
        get { return destination; }
        set { destination = value; }
    }

    #endregion

}