using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConstructionFrame : InteractableWorldObject
{

    [SerializeField]
    private int resourceRequired = 3; // = HousingData.resourceCost kanske?
    [SerializeField]
    private int resourceCurrent = 0;
    [SerializeField]
    private GameObject actualHousePrefab;
    [SerializeField]
    private GameObject houseProgressVisualizer;


    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8) //Terrain
        {
            var rotation = transform.rotation;

            RaycastHit hitInfo;
            LayerMask mask = LayerMask.GetMask("Terrain");
            Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hitInfo, 100.0f, mask);

            rigi.isKinematic = true;

            transform.position = hitInfo.point;
            var localYRotation = rotation.eulerAngles.y;
            rotation.eulerAngles = (new Vector3(0.0f, localYRotation, 0.0f));
            transform.rotation = rotation;

        }

        if (collision.collider.name == "Tree_05_Downscaled_LOD")
        {
            if (resourceCurrent < resourceRequired)
            {
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
        var house = Object2.Instantiate<GameObject>(actualHousePrefab, transform.position, Quaternion.identity);
        house.transform.localScale = transform.localScale;
        house.transform.localRotation = transform.localRotation;
        house.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 0.0f);

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

        houseProgressVisualizer.transform.DOPunchScale(Vector3.one * 0.25f, 0.25f, 13, 1);
    }

}
