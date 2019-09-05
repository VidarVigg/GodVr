using UnityEngine;

public class NullAudioService : IAudioMasterService
{

    #region Methods

    public void PlayLoop(MenuAudioType menuAudioType) { }

    public void PlayLoop(MenuAudioType menuAudioType, WorldObject worldObject) { }

    public void PlayLoop(MenuAudioType menuAudioType, Vector3 position) { }



    public void PlayLoop(GameAudioType gameAudioType) { }

    public void PlayLoop(GameAudioType gameAudioType, WorldObject worldObject) { }

    public void PlayLoop(GameAudioType gameAudioType, Vector3 position) { }



    public void PlayOneShot(MenuAudioType menuAudioType) { }

    public void PlayOneShot(MenuAudioType menuAudioType, WorldObject worldObject) { }

    public void PlayOneShot(MenuAudioType menuAudioType, Vector3 position) { }



    public void PlayOneShot(GameAudioType gameAudioType) { }

    public void PlayOneShot(GameAudioType gameAudioType, WorldObject worldObject) { }

    public void PlayOneShot(GameAudioType gameAudioType, Vector3 position) { }

    #endregion

}
