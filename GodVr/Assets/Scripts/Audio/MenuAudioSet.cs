using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGameSet", menuName = "AudioSet/Menu")]
public class MenuAudioSet : ScriptableObject
{
    
    [SerializeField] private AudioObject[] audioObjects = new AudioObject[4];

}