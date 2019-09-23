using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Treee : NaturalMaster
{

    [SerializeField] TreeeConfig treeeConfig = new TreeeConfig();

    public override void Grab(Controller123 controller,Rigidbody attach)
    {
        rigi.isKinematic = false;


        if (joint)
        {
            return;
        }

        joint = gameObject.AddComponent<FixedJoint>();
        transform.position = attach.position;
        joint.connectedBody = attach;
        controller.Obj = this;
        controller.State = ControllerState.Holding;
    }

    protected override void OnTriggerEnter(Collider collider)
    {

        if (rigi.velocity.sqrMagnitude >= 0.05)
        {
            if (collider.gameObject.layer == 10)
            {
                if (treeeConfig.ParticleSystem)
                {
                    var obj = Object2.Instantiate<GameObject>(treeeConfig.ParticleSystem, collider.transform, true);
                    obj.transform.SetParent(null);
                    obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    obj.SetActive(true);
                    //ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXEnemyImpact, treeeConfig.AudioSource);
                    Destroy(obj, 2f);
                    Destroy(gameObject);
                }
            }
            //treeeConfig.ParticleSystem.Play();
            //Debug.Log(collider.gameObject);

            //Debug.Log("tree was moving");
            //if (collider.gameObject.layer == 10)
            //{
            //    Debug.Log("Enemy");
            //    treeeConfig.ParticleSystem.Play();
            //    Destroy(gameObject, 1f);
            //}
        }
        else
        {
            Debug.Log("Treee was not moving");
        }

    }

    public override bool Place(Controller123 stuff, Vector3 placePosition, Quaternion placeRotation)
    {
        return false;
    }
}
