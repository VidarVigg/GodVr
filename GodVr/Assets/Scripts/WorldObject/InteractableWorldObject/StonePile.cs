using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePile : NaturalMaster
{
    [SerializeField]
    private GameObject rockPrefab;

    public override void Grab(Controller123 controller,Rigidbody attach)
    {
        //base.Grab(attach);
        GameObject gameobject = Instantiate(rockPrefab);
        gameobject.GetComponent<Rock>().Grab(controller, attach);

    }
}
