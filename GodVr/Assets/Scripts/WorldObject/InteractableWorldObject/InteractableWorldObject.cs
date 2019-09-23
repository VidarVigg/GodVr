using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof (AudioSource)), ]
public abstract class InteractableWorldObject : WorldObject
{

    [SerializeField]
    protected Rigidbody rigi;

    [SerializeField]
    protected FixedJoint joint;

    [SerializeField]
    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        rigi = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public virtual void Grab(Controller123 controller, Rigidbody attach)
    {

        if (controller.State == ControllerState.Holding)
        {
            return;
        }

        if (joint)
        {
            return;
        }

        joint = gameObject.AddComponent<FixedJoint>();
        transform.position = attach.position;
        joint.connectedBody = attach;
        controller.Obj = this;
        controller.State = ControllerState.Holding;
        ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXGrab, audioSource);
    }

    public virtual bool Place(Controller123 stuff, Vector3 placePosition, Quaternion placeRotation)
    {
        Object.DestroyImmediate(joint);
        joint = null;

        transform.position = placePosition;
        transform.rotation = placeRotation;
        stuff.Obj = null;
        stuff.State = ControllerState.Empty;
        return true;
    }


    public virtual void Throw(SteamVR_Behaviour_Pose trackedObj)
    {

        Object.DestroyImmediate(joint);
        joint = null;

        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            rigi.velocity = origin.TransformVector(trackedObj.GetVelocity());
            rigi.angularVelocity = origin.TransformVector(trackedObj.GetAngularVelocity());
        }
        else
        {
            rigi.velocity = trackedObj.GetVelocity();
            rigi.angularVelocity = trackedObj.GetAngularVelocity();
        }

        rigi.maxAngularVelocity = rigi.angularVelocity.magnitude;
        ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXThrow, audioSource);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXImpact, audioSource);
    }
}
