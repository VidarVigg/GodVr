using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeSpawner : NaturalMaster
{
    [Header("Spawner Variables")]
    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private ParticleSystem pineParticles;
    [SerializeField]
    private float respawnTime = 2;

    private float timer;
    private bool isGrabbable = true;

    [Header("Punch Variables")]

    [SerializeField]
    private float punchMultiplier = 0.25f;
    [SerializeField]
    private float punchTime = 0.5f;
    [SerializeField]
    private int punchVibrato = 10;
    [SerializeField]
    private float punchElasticity = 1.0f;



    private void Update()
    {
        // Apparently better than a coroutine, timer to control if new tree is grabbable
        if (!isGrabbable)
        {
            if (timer >= respawnTime)
            {
                isGrabbable = true;
                timer = 0;
                transform.DOPunchScale(Vector3.one * punchMultiplier, punchTime, punchVibrato, punchElasticity);
                pineParticles.Play();
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
            pineParticles.Play();
            //base.Grab(attach);
            GameObject gameobject = Object2.Instantiate(treePrefab);
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