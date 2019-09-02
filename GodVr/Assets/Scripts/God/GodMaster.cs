using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMaster : MonoBehaviour
{
    [SerializeField] private GodData data = new GodData();
    [SerializeField] private GodConfig config = new GodConfig();
    [SerializeField] private GodController controller;
    
    private void Awake()
    {
        controller = new GodController(data, config, this);
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
