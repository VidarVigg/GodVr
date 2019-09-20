using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TreeeConfig
{
    [SerializeField] private GameObject particleSystem;

    [SerializeField] private AudioSource audioSource;

    public GameObject ParticleSystem
    {
        get { return particleSystem; }
        set { particleSystem = value; }
    }
    public AudioSource AudioSource
    {
        get { return audioSource; }
        set { audioSource = value; }
    }
}
