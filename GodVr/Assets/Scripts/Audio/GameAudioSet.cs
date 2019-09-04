using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGameSet", menuName = "AudioSet/Game")]
public class GameAudioSet : ScriptableObject
{

    [SerializeField] private AudioObject[] audioObjects = new AudioObject[4];

}