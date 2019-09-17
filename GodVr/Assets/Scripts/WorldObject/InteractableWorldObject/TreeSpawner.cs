using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeSpawner : NaturalMaster
{

    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private float respawnTime = 2;
    private float timer;

    private bool isGrabbable = true;

    private void Update()
    {
        // Apparently better than a coroutine, timer to control if new tree is grabbable
        if (!isGrabbable)
        {
            if (timer >= respawnTime)
            {
                isGrabbable = true;
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }



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
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        transform.DOScale(1, respawnTime);

        isGrabbable = false;

    }
}