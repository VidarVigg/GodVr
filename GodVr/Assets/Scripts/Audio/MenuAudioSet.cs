using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGameSet", menuName = "AudioSet/Menu")]
public class MenuAudioSet : ScriptableObject
{
    [SerializeField] private AudioClip option;
    [SerializeField] private AudioClip select;

}