using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioMasterService
{
    void PlayOneShot(AudioType audioType, AudioSource audioSource);
}
