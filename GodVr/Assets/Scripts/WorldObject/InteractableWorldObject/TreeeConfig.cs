using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TreeeConfig
{
    [SerializeField] private ParticleSystem particleSystem;

    public ParticleSystem ParticleSystem
    {
        get { return particleSystem; }
        set { particleSystem = value; }
    }
}
