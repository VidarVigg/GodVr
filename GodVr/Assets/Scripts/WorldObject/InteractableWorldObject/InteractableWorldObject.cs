using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(AudioSource)),]
public abstract class InteractableWorldObject : WorldObject
{

    [SerializeField]
    protected Rigidbody rigi;

    [SerializeField]
    public FixedJoint joint;

    [SerializeField]
    public Controller123 heldBy;


    [SerializeField]
    protected AudioSource audioSource;

    [SerializeField]
    protected float soundImpactThreshold = 0.05f;


    protected virtual void Awake()
    {
        rigi = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public virtual void Grab(Controller123 controller, Rigidbody attach)
    {
        rigi.isKinematic = false;

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
        heldBy = controller;
        controller.Obj = this;
        controller.State = ControllerState.Holding;
        ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXGrab, audioSource);
    }

    public virtual bool Place(Vector3 placePosition, Quaternion placeRotation)
    {
        Drop();
        transform.position = placePosition;
        transform.rotation = placeRotation;
        rigi.isKinematic = true;
        return true;
    }


    public virtual void Throw(SteamVR_Behaviour_Pose trackedObj)
    {

        Drop();

        rigi.isKinematic = false;

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
    public virtual void Drop()
    {
        Object.DestroyImmediate(joint);
        joint = null;

        //Makes sure the controller we held is set correctly
        heldBy.Obj = null;
        heldBy.State = ControllerState.Empty;
        heldBy = null;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (rigi.velocity.sqrMagnitude > soundImpactThreshold)
        {
            ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXImpact, audioSource);
        }
    }
}
