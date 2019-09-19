using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : NaturalMaster
{
    [SerializeField]
    [Range(0.05f, 5.0f)]
    private float vfxSpawnThreshold = 0.05f;

    [SerializeField]
    private GameObject particleSystem;

    [SerializeField]
    private AudioSource audioSource = null;

    public override bool Place(Controller123 stuff, Vector3 placePosition, Quaternion placeRotation)
    {
        return false;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (rigi.velocity.sqrMagnitude >= vfxSpawnThreshold)
        {
            if (particleSystem)
            {
                var obj = Object2.Instantiate<GameObject>(particleSystem, collision.GetContact(0).point, Quaternion.identity, null);
                ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXEnemyImpact, audioSource);
                Destroy(obj, 2.0f);
            }
        }
    }

}