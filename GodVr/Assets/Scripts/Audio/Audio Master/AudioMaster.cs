using UnityEngine;

public class AudioMaster : MonoBehaviour, IAudioMasterService
{

    [SerializeField]
    private AudioConfig testAudioConfig = null;
    [SerializeField]
    private AudioData testAudioData = null;

    private AudioController testAudioController = null;


    private void Awake()
    {
        testAudioController = new AudioController(this, testAudioConfig, testAudioData);
    }

    private void Start()
    {

    }
    private void Update()
    {

    }


    public void Playsound(AudioType testAudioType, AudioSource audioSource)
    {
        testAudioController.PlaySound(testAudioType, audioSource);
    }
}
