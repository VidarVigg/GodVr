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

        audioData.AudioObjectsMenu = new AudioObject[audioConfig.GameAudioSet.GameAudioObject.Length]; //Change GameAudioSet to MenuAudioSet

        for (int i = 0; i < audioConfig.GameAudioSet.GameAudioObject.Length; i++) //Change GameAudioSet to MenuAudioSet
        {
            audioData.AudioObjectsMenu[i] = audioConfig.GameAudioSet.GameAudioObject[i]; //Change GameAudioSet to MenuAudioSet
        }

        audioData.AudioObjectsGame = new AudioObject[audioConfig.GameAudioSet.GameAudioObject.Length];

        for (int i = 0; i < audioConfig.GameAudioSet.GameAudioObject.Length; i++)
        {
            audioData.AudioObjectsGame[i] = audioConfig.GameAudioSet.GameAudioObject[i];
        }

    }

    #endregion

}