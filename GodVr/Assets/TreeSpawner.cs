using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : NaturalMaster
{
    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private float respawnTime;
    private float yScale;

    private bool isGrabbable = true;



    public override void Grab(Controller123 controller, Rigidbody attach)
    {
        if (isGrabbable)
        {
            Regrow();

            //base.Grab(attach);
            GameObject gameobject = Instantiate(treePrefab);
            gameobject.GetComponent<Treee>().Grab(controller, attach);

        }

        else
        {
            Debug.Log("Tree is not ready yet");
        }


    }

    private void Regrow()
    {
        transform.localScale = new Vector3(1, 0.01f, 1);
    }
}
