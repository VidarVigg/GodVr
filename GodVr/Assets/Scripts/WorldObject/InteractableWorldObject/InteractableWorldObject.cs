using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public abstract class InteractableWorldObject : WorldObject
{

    [SerializeField]
    protected Rigidbody rigi;

    [SerializeField]
    protected FixedJoint joint;

    protected virtual void Awake()
    {
        rigi = gameObject.GetComponent<Rigidbody>();
    }

    public virtual void Grab(Rigidbody attach) {

        
        if (joint)
        {
            return;
        }

        joint = gameObject.AddComponent<FixedJoint>();
        transform.position = attach.position;
        joint.connectedBody = attach;

    }

    public virtual void Place(Vector3 placePosition,Quaternion placeRotation ) {
        Object.DestroyImmediate(joint);
        joint = null;

        transform.position = placePosition;
        transform.rotation = placeRotation;
    }


    public virtual void Throw(SteamVR_Behaviour_Pose trackedObj) {

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
    }   
}
