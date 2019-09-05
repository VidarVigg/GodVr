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

    public GameObject whatever;

    private void Awake()
    {
        audioController = new AudioController(this, audioConfig, audioData);
        Initialize();


        GameObject cube =  Object2.Instantiate(whatever);
        cube.name = cube.name + "(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)(Clone)";



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


    public void PlayLoop(MenuAudioType menuAudioType)
    {

    }

    public void PlayLoop(MenuAudioType menuAudioType, WorldObject worldObject)
    {

    }

    public void PlayLoop(MenuAudioType menuAudioType, Vector3 position)
    {

    }

    public void PlayLoop(GameAudioType gameAudioType)
    {

    }

    public void PlayLoop(GameAudioType gameAudioType, WorldObject worldObject)
    {

    }

    public void PlayLoop(GameAudioType gameAudioType, Vector3 position)
    {

    }

    public void PlayOneShot(MenuAudioType menuAudioType)
    {

    }

    public void PlayOneShot(MenuAudioType menuAudioType, WorldObject worldObject)
    {

    }

    public void PlayOneShot(MenuAudioType menuAudioType, Vector3 position)
    {

    }

    public void PlayOneShot(GameAudioType gameAudioType)
    {

    }

    public void PlayOneShot(GameAudioType gameAudioType, WorldObject worldObject)
    {

    }

    public void PlayOneShot(GameAudioType gameAudioType, Vector3 position)
    {

    }


    #endregion

}