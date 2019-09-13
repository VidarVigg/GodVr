﻿using System;
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

    [SerializeField]
    private HousingMaster target;

    [SerializeField]
    private Animator animator;


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

    public HousingMaster Target
    {
        get { return target; }
        set { target = value; }
    }

    public Animator Animator
    {
        get { return animator; }
        set { animator = value; }
    }

    #endregion

}