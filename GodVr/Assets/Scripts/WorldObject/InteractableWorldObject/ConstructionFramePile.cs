using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionFramePile : NaturalMaster
{
    [SerializeField]
    private GameObject constructionFramePrefab;

    [SerializeField]
    private GameObject thingy;

    private void Update()
    {
        thingy.transform.Rotate(new Vector3(0, 1, 0));
        thingy.transform.localPosition = new Vector3(0, (float)(1.17 + Mathf.Sin(Time.frameCount / 50.0f) * 0.05f), 0);
    }

    public override void Grab(Controller123 controller,Rigidbody attach)
    {
        GameObject gameobject = Instantiate(constructionFramePrefab);
        gameobject.GetComponent<HouseScaffolding>().Grab(controller, attach);
    }
}
