﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackMaster : MonoBehaviour
{
    [SerializeField] JackData data = new JackData();
    private void Awake()
    {
        data.source = GetComponent<AudioSource>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ServiceLocator.TestAudioMasterService.Playsound(AudioType.Test, data.source);
            ServiceLocator.TestAudioMasterService.Playsound(AudioType.Null, data.source);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
        }
    }
}