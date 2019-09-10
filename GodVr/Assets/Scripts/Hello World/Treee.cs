using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Treee : NaturalMaster
{

    public override void Throw(SteamVR_Behaviour_Pose trackedObj)
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
        Debug.Log("I'm a tree being thrown");
        rigi.useGravity = true;
    }
    //public override void Grab(Rigidbody attach)
    //{
    //    Debug.Log("I'm a tree being thrown");
    //    rigi.useGravity = true;
    //}
}
