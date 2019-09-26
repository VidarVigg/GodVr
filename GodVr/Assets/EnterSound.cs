using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private float tick;
    private float max = 10;

    private void Update()
    {
        tick += Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitAIMaster>())
        {
            if (tick > max)
            {
                ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXScream, audioSource);
                tick = 0;
            }
        }
    }
}
