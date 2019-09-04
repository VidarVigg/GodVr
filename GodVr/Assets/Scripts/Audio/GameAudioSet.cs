using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGameSet", menuName = "AudioSet/Game")]
public class GameAudioSet : ScriptableObject
{

    #region Fields

    [SerializeField] private AudioObject[] audioObjects = new AudioObject[4];

    #endregion

    #region Properties

    public AudioObject[] AudioObjects { get { return audioObjects; }}

    #endregion


}