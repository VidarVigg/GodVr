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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SetMusic(AudioType.MusicRegular);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetMusic(AudioType.MusicWin);
        }
    }

    public void SetMusic(AudioType audioType)
    {
        audioController.PlayMusic(audioType);
    }

    #endregion

}
