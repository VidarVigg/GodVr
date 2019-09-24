using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroyHouseSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXHouseDestroy, audioSource);
    }

}
