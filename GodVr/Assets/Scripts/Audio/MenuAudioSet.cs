using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGameSet", menuName = "AudioSet/Menu")]
public class MenuAudioSet : ScriptableObject
{

    #region Fields

    [SerializeField] private AudioObject[] audioObjects = new AudioObject[] 
    {

        new AudioObject(AudioType.Select, null),

    };

    #endregion

    #region Properties

    public AudioObject[] AudioObjects { get { return audioObjects; } }

    #endregion

}