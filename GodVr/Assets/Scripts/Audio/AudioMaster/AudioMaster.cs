using UnityEngine;

public class AudioMaster : WorldObject, IAudioMasterService
{

    #region Fields

    [SerializeField]
    private AudioConfig audioConfig = null;

    [SerializeField]
    private AudioData audioData = null;

    private AudioController audioController = null;

    #endregion

    #region Methods

    public GameObject whatever;

    private void Awake()
    {
        audioController = new AudioController(this, audioConfig, audioData);
        Initialize();
    }

    private void Initialize()
    {

        //audioData.AudioObjectsMenu = new AudioObject[audioConfig.GameAudioSet.GameAudioObject.Length]; //Change GameAudioSet to MenuAudioSet

        //for (int i = 0; i < audioConfig.GameAudioSet.GameAudioObject.Length; i++) //Change GameAudioSet to MenuAudioSet
        //{
        //    audioData.AudioObjectsMenu[i] = audioConfig.GameAudioSet.GameAudioObject[i]; //Change GameAudioSet to MenuAudioSet
        //}

        //audioData.AudioObjectsGame = new AudioObject[audioConfig.GameAudioSet.GameAudioObject.Length];

        //for (int i = 0; i < audioConfig.GameAudioSet.GameAudioObject.Length; i++)
        //{
        //    audioData.AudioObjectsGame[i] = audioConfig.GameAudioSet.GameAudioObject[i];
        //}

    }

    public void PlayOneShot(MenuAudioType menuAudioType, AudioOptions options = null)
    {

    }

    public void PlayOneShot(GameAudioType gameAudioType, AudioOptions options = null)
    {

    }

    public void PlayLoop(MenuAudioType menuAudioType, AudioOptions options = null)
    {

    }

    public void PlayLoop(GameAudioType gameAudioType, AudioOptions options = null)
    {

    }

    public void StopLoop(GameAudioType gameAudioType, AudioSource source)
    {

    }

    public void StopLoop(MenuAudioType menuAudioType, AudioSource source)
    {

    }

    public void StopAllLoops(AudioSource source)
    {

    }

    #endregion

}