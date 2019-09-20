using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScaffolding : InteractableWorldObject
{

    [SerializeField]
    private int resourceRequired = 3; // = HousingData.resourceCost kanske?
    [SerializeField]
    private int resourceCurrent = 0;
    [SerializeField]
    private GameObject actualHousePrefab;
    [SerializeField]
    private GameObject houseProgressVisualizer;
    [SerializeField]
    private Transform targetTransformInHierarchy;


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
        var house = Object2.Instantiate<GameObject>(actualHousePrefab, transform.position, Quaternion.identity, targetTransformInHierarchy);
        house.transform.localScale = transform.localScale;
        //TODO: Implement Place() after the house has been instantiated
        //Update: Place doesn't do anything besides removing it from your hand?
        //So maybe use this?
        //house.GetComponent<Rigidbody>().isKinematic = true;
        //Remember to disable kinematics when throwing/releasing it later on
    }

    private void UpdateProgressionVisuals(int progress)
    {
        if (houseProgressVisualizer.activeSelf == false)
            houseProgressVisualizer.SetActive(true);

        houseProgressVisualizer.transform.localScale = new Vector3(1, (1 / (float)resourceRequired) * progress, 1);
    }

}
