//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;

namespace Valve.VR.Extras
{
    [RequireComponent(typeof(SteamVR_TrackedObject))]
    public class SteamVR_TestThrow : MonoBehaviour
    {
        public GameObject prefab;
        public Rigidbody attachPoint;
        
        public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

        SteamVR_Behaviour_Pose trackedObj;
        FixedJoint joint;

        private void Awake()
        {
            trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        }

        private void FixedUpdate()
        {
            if (joint == null && spawn.GetStateDown(trackedObj.inputSource))
            {
                GameObject go = GameObject.Instantiate(prefab);
                go.transform.position = attachPoint.transform.position;

                joint = go.AddComponent<FixedJoint>();
                joint.connectedBody = attachPoint;
            }
            else if (joint != null && spawn.GetStateUp(trackedObj.inputSource))
            {
                GameObject go = joint.gameObject;
                Rigidbody rigidbody = go.GetComponent<Rigidbody>();
                Object.DestroyImmediate(joint);
                joint = null;
                Object.Destroy(go, 15.0f);

                // We should probably apply the offset between trackedObj.transform.position
                // and device.transform.pos to insert into the physics sim at the correct
                // location, however, we would then want to predict ahead the visual representation
                // by the same amount we are predicting our render poses.

                Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
                if (origin != null)
                {
                    rigidbody.velocity = origin.TransformVector(trackedObj.GetVelocity());
                    rigidbody.angularVelocity = origin.TransformVector(trackedObj.GetAngularVelocity());
                }
                else
                {
                    rigidbody.velocity = trackedObj.GetVelocity();
                    rigidbody.angularVelocity = trackedObj.GetAngularVelocity();
                }

                rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
            }
        }
    }
}

//Vector3 startPoint;
//Vector3 currentPoint;
//bool moving;
//public GameObject rig;
//[Range(1.0f, 5.0f)]
//public float moveSpeed = 1.0f;

//private void Awake()
//{
//    trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
//    startPoint = new Vector3(0, 0, 0);
//    currentPoint = new Vector3(0, 0, 0);
//    moving = false;
//}

//private void FixedUpdate()
//{
//    if (spawn.GetStateDown(trackedObj.inputSource))
//    {
//        Debug.Log("Pressed: " + trackedObj.inputSource);
//        startPoint = trackedObj.transform.position;
//        moving = true;
//    }
//    else if (spawn.GetStateUp(trackedObj.inputSource))
//    {
//        Debug.Log("Released: " + trackedObj.inputSource);
//        startPoint = Vector3.zero;
//        currentPoint = Vector3.zero;
//        moving = false;
//    }

//    currentPoint = transform.position;

//    if (moving)
//    {
//        var pos = rig.transform.position + ((startPoint - currentPoint) * moveSpeed);

//        rig.transform.position = new Vector3(pos.x, 0, pos.z);
//    }