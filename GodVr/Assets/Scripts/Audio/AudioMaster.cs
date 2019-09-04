using UnityEngine;

public class AudioMaster : MonoBehaviour
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
        InitializeData();
    }

    private void InitializeData()
    {

        audioData.AudioObjectsMenu = new AudioObject[audioConfig.GameAudioSet.AudioObjects.Length]; //Change GameAudioSet to MenuAudioSet

        for (int i = 0; i < audioConfig.GameAudioSet.AudioObjects.Length; i++) //Change GameAudioSet to MenuAudioSet
        {
            audioData.AudioObjectsMenu[i] = audioConfig.GameAudioSet.AudioObjects[i]; //Change GameAudioSet to MenuAudioSet
        }

        audioData.AudioObjectsGame = new AudioObject[audioConfig.GameAudioSet.AudioObjects.Length];

        for (int i = 0; i < audioConfig.GameAudioSet.AudioObjects.Length; i++)
        {
            audioData.AudioObjectsGame[i] = audioConfig.GameAudioSet.AudioObjects[i];
        }

    }

    #endregion

}