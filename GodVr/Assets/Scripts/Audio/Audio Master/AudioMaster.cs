using UnityEngine;

public class AudioMaster : MonoBehaviour, IAudioMasterService
{

    #region Fields

    [SerializeField]
    private AudioConfig audioConfig = null;
    [SerializeField]
    private AudioData audioData = null;

    private AudioController audioController = null;

    #endregion

    #region Methods

    private void Awake()
    {
        audioController = new AudioController(this, audioConfig, audioData);
    }

    public void PlayOneShot(AudioType testAudioType, AudioSource audioSource)
    {
        audioController.PlaySound(testAudioType, audioSource);
    }

    #endregion

}
