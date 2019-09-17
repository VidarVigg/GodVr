using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : NaturalMaster
{

    public override bool Place(Controller123 stuff, Vector3 placePosition, Quaternion placeRotation)
    {
        return false;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        //particle systems
    }

}