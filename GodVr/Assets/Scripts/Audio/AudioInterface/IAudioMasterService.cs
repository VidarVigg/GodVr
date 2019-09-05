using UnityEngine;

public interface IAudioMasterService
{
    #region Methods

    void PlayOneShot(MenuAudioType menuAudioType);
    void PlayOneShot(MenuAudioType menuAudioType, WorldObject worldObject);
    void PlayOneShot(MenuAudioType menuAudioType, Vector3 position);

    void PlayOneShot(GameAudioType gameAudioType);
    void PlayOneShot(GameAudioType gameAudioType, WorldObject worldObject);
    void PlayOneShot(GameAudioType gameAudioType, Vector3 position);

    void PlayLoop(MenuAudioType menuAudioType);
    void PlayLoop(MenuAudioType menuAudioType, WorldObject worldObject);
    void PlayLoop(MenuAudioType menuAudioType, Vector3 position);

    void PlayLoop(GameAudioType gameAudioType);
    void PlayLoop(GameAudioType gameAudioType, WorldObject worldObject);
    void PlayLoop(GameAudioType gameAudioType, Vector3 position);

    #endregion
}
