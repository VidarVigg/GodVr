using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITesting : MonoBehaviour
{

    [SerializeField]
    private ProgressbarMaster progressbar;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            progressbar.SetValue(75);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            progressbar.SetValue(25);
        }

    }

}
