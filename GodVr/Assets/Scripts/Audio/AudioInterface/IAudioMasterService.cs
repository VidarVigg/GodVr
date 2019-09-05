using UnityEngine;

public interface IAudioMasterService
{
    #region Methods

    void PlayOneShot(MenuAudioType menuAudioType, AudioOptions options = null);

    void PlayOneShot(GameAudioType gameAudioType, AudioOptions options = null);

    void PlayLoop(MenuAudioType menuAudioType, AudioOptions options = null);

    void PlayLoop(GameAudioType gameAudioType, AudioOptions options = null);

    void StopLoop(GameAudioType gameAudioType, AudioSource source);

    void StopLoop(MenuAudioType menuAudioType, AudioSource source);

    void StopAllLoops(AudioSource source);

    #endregion
}
