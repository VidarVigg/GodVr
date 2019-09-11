﻿using UnityEngine;

public class AudioController
{
    #region Fields

    private AudioMaster testAudioMaster = null;

    private AudioConfig testAudioConfig = null;

    private AudioData testAudioData = null;

    #endregion

    #region Constructors

    private AudioController() { }
    public AudioController(AudioMaster testAudioMaster, AudioConfig testAudioConfig, AudioData testAudioData)
    {
        this.testAudioMaster = testAudioMaster;
        this.testAudioConfig = testAudioConfig;
        this.testAudioData = testAudioData;
    }

    #endregion

    #region Methods

    public void PlaySound(AudioType testAudioType, AudioSource audioSource)
    {
        for (int i = 0; i < testAudioConfig.AudioStructs.Length; i++)
        {
            if (testAudioConfig.AudioStructs[i].type == testAudioType)
            {
                audioSource?.PlayOneShot(testAudioConfig.AudioStructs[i].clip);
            }
            
        }
        
    }

    #endregion

}