using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    #region Fields

    [SerializeField] private AudioMaster audioMaster = null;
    [SerializeField] private AudioConfig audioConfig = null;
    [SerializeField] private AudioData audioData = null;

    #endregion

    #region Constructors

    private AudioController() { }
    public AudioController(AudioMaster audioMaster, AudioConfig audioConfig, AudioData audioData)
    {
        this.audioMaster = audioMaster;
        this.audioConfig = audioConfig;
        this.audioData = audioData;
    }

    #endregion

    #region Methods



    #endregion

}
