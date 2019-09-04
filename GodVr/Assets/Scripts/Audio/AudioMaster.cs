using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    [SerializeField] private AudioConfig audioConfig = null;
    [SerializeField] private AudioData audioData = null;

    private AudioController audioController = null;

    private void Awake()
    {
        audioController = new AudioController(this, audioConfig, audioData);
        audioData.AudioObjectsGame = new AudioObject[audioConfig.GameAudioSet.AudioObjects.Length];
        for (int i = 0; i < audioConfig.GameAudioSet.AudioObjects.Length; i++)
        {

            audioData.AudioObjectsGame[i] = audioConfig.GameAudioSet.AudioObjects[i];

        }

    }

    void Start()
    {

    }


    void Update()
    {

    }
}
