using UnityEngine;

public class NullAudioService : IAudioMasterService
{

    #region Methods

    public void PlayLoop(MenuAudioType menuAudioType, AudioOptions options = null)
    {
        throw new System.NotImplementedException();
    }

    public void PlayLoop(GameAudioType gameAudioType, AudioOptions options = null)
    {
        throw new System.NotImplementedException();
    }

    public void PlayOneShot(MenuAudioType menuAudioType, AudioOptions options = null)
    {
        throw new System.NotImplementedException();
    }

    public void PlayOneShot(GameAudioType gameAudioType, AudioOptions options = null)
    {
        throw new System.NotImplementedException();
    }

    public void StopAllLoops(AudioSource source)
    {
        throw new System.NotImplementedException();
    }

    public void StopLoop(GameAudioType gameAudioType, AudioSource source)
    {
        throw new System.NotImplementedException();
    }

    public void StopLoop(MenuAudioType menuAudioType, AudioSource source)
    {
        throw new System.NotImplementedException();
    }

    #endregion

}
