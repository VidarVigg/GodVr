using UnityEngine;

public class AudioController
{

    #region Fields

    private AudioMaster testAudioMaster = null;

    private AudioConfig testAudioConfig = null;

    private AudioData testAudioData = null;

    #endregion

    #region Constructors

    private AudioController() { }
    public AudioController(AudioMaster testAudioMaster, AudioConfig testAudioConfig, AudioData testAudioData)
    {
        this.testAudioMaster = testAudioMaster;
        this.testAudioConfig = testAudioConfig;
        this.testAudioData = testAudioData;
    }

    #endregion

    #region Methods

    public void PlaySound(AudioType testAudioType, AudioSource audioSource)
    {
        for (int i = 0; i < testAudioConfig.AudioStructs.Length; i++)
        {
            if (testAudioConfig.AudioStructs[i].type == testAudioType)
            {
                if (testAudioConfig.AudioStructs[i].clip != null)
                {
                    audioSource?.PlayOneShot(testAudioConfig.AudioStructs[i].clip[Random.Range(0, testAudioConfig.AudioStructs[i].clip.Length)], testAudioConfig.AudioStructs[i].volume);
                }
                else
                {
                    Debug.LogWarning("<b> No Audio Clip in Source! </b>");
                }
            }

        }

    }
    public void PlayMusic(AudioType testAudioType)
    {
        for (int i = 0; i < testAudioConfig.AudioStructs.Length; i++)
        {
            if (testAudioConfig.AudioStructs[i].type == testAudioType)
            {
                if (testAudioConfig.AudioStructs[i].clip != null)
                {
                    if (testAudioType == AudioType.MusicWin)
                    {
                        testAudioConfig.AudioStructs[i].musicAudioSource.volume = 1;
                    }
                    else
                    {

                        testAudioConfig.AudioStructs[i].musicAudioSource.volume = 0.35f;
                    }
                    testAudioConfig.AudioStructs[i].musicAudioSource.clip = testAudioConfig.AudioStructs[i].clip[0];
                    testAudioConfig.AudioStructs[i].musicAudioSource.Play();
                }
                else
                {
                    Debug.LogWarning("<b> No Audio Clip in Source! </b>");
                }
            }

        }

    }


    #endregion

}