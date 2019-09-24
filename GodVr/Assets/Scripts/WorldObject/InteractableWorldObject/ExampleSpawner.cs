using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSpawner : InteractableWorldObject
{
    [SerializeField]
    private GameObject gamePrefab;

    [SerializeField]
    private GameObject visual;

    private enum Thing
    {
        Rock,
        Tree,
        House,
        ConstructionFrame
    }

    [SerializeField]
    private Thing selectObjectToSpawn;

    private void Update()
    {
        visual.transform.Rotate(new Vector3(0, 1, 0));
        visual.transform.localPosition = new Vector3(0, (float)(1.25 + Mathf.Sin(Time.frameCount / 50.0f) * 0.05f), 0);
    }

    public override void Grab(Controller123 controller,Rigidbody attach)
    {
        GameObject gameobject = Object2.Instantiate(gamePrefab);

        switch (selectObjectToSpawn)
        {
            case Thing.Rock:
                gameobject.GetComponent<Rock>().Grab(controller, attach);
                break;
            case Thing.Tree:
                gameobject.GetComponent<Treee>().Grab(controller, attach);
                break;
            case Thing.House:
                gameobject.GetComponent<HousingMaster>().Grab(controller, attach);
                gameobject.transform.SetParent(GameObject.Find("Houses").transform); //Temp
                gameobject.transform.localScale = Vector3.one;
                break;
            case Thing.ConstructionFrame:
                gameobject.GetComponent<ConstructionFrame>().Grab(controller, attach);
                break;

            default:
                break;
        }
    }
}
