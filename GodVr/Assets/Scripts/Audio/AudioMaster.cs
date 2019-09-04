using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    [SerializeField] private AudioConfig audioConfig = null;
    [SerializeField] private AudioData audioData = null;

    private AudioController audioController = null;

    private void Awake()
    {
        audioController = new AudioController(this, audioConfig, audioData);
        for (int i = 0; i < audioData.AudioObjectsGame.Length; i++)
        {
            audioData.AudioObjectsGame[i].AudioClip = audioConfig.GameAudioSet.AudioObjects[i].AudioClip;
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
