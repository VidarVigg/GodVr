using UnityEngine;

public class AudioController
{

    #region Fields

    [SerializeField]
    private AudioMaster audioMaster = null;

    [SerializeField]
    private AudioConfig audioConfig = null;

    [SerializeField]
    private AudioData audioData = null;

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

    public void PlayOneShot(GameAudioType gameAudioType, AudioOptions audioOptions = null)
    {

        AudioSource audioSource = null;

        

        if (audioOptions == null)
        {
            //audioSource = ServiceLocator.CameraMasterService.gameObject.AddComponent<AudioSource>();
        }

        else if (audioOptions.WorldObject != null)
        {
            if (audioOptions.WorldObject.gameObject.GetComponent<AudioSource>()) // Change this code!
            {
                return;
            }
            audioSource = audioOptions.WorldObject.gameObject.AddComponent<AudioSource>();
        }

        else
        {
            audioSource = new GameObject().AddComponent<AudioSource>();
            audioSource.transform.position = audioOptions.Position;
        }

        audioSource.PlayOneShot(audioData.AudioObjectsGame[Brujin.Position((int)gameAudioType)].AudioClip);

    }

    public void PlayLoop(GameAudioType gameAudioType, AudioOptions audioOptions = null)
    {
        
    }

    #endregion

}
