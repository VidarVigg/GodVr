using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : NaturalMaster
{
    [SerializeField]
    [Range(0.05f, 5.0f)]
    private float vfxSpawnThreshold;

    [SerializeField]
    private ParticleSystem particleSystem;

    public override bool Place(Controller123 stuff, Vector3 placePosition, Quaternion placeRotation)
    {
        return false;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (rigi.velocity.sqrMagnitude >= vfxSpawnThreshold)
        {
            particleSystem.Play();
        }
    }

}