using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGameSet", menuName = "AudioSet/Game")]
public class GameAudioSet : ScriptableObject
{

    #region Fields

    [SerializeField]
    private AudioObject[] audioObjects = new AudioObject[]
    {
        new AudioObject(AudioType.PickUp, null),
        new AudioObject(AudioType.PutDown, null),

    };

    #endregion

    #region Properties

    public AudioObject[] AudioObjects { get { return audioObjects; }}

    #endregion


}