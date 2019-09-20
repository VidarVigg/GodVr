using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScaffolding : InteractableWorldObject
{

    [SerializeField]
    private int resourceRequired = 3;
    [SerializeField]
    private int resourceCurrent = 0;

    [SerializeField]
    private GameObject houseToBuild;

    [SerializeField]
    private GameObject housePreViz;

    public Transform housesParent;


    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Treee>())
        {
            if (resourceCurrent < resourceRequired)
            {
                //TODO: Figure out how to reliably only get one collider from tree prefab
                Destroy(collision.gameObject);
                IncreaseBuildingProgression();
            }
        }
    }

    private void IncreaseBuildingProgression()
    {
        resourceCurrent++;

        if (resourceCurrent == resourceRequired)
        {
            FinishConstruction();
            return;
        }

        UpdateProgressionVisuals(resourceCurrent);
    }

    private void FinishConstruction()
    {
        gameObject.SetActive(false);
        var house = Instantiate<GameObject>(houseToBuild, transform.position, Quaternion.identity, housesParent);
        //TODO: Implement Place() after the house has been instantiated
        //Update: Place doesn't do anything besides removing it from your hand?
        //So maybe use this?
        //house.GetComponent<Rigidbody>().isKinematic = true;
        //Remember to disable kinematics when throwing/releasing it later on
    }

    private void UpdateProgressionVisuals(int progress)
    {
        if (housePreViz.activeSelf == false)
            housePreViz.SetActive(true);

        housePreViz.transform.localScale = new Vector3(1, (1 / (float)resourceRequired) * progress, 1);
    }

}
