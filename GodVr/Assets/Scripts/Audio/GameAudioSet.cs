using UnityEngine;

[CreateAssetMenu(fileName = "DefaultGameSet", menuName = "AudioSet/Game")]
public class GameAudioSet : ScriptableObject
{

    [SerializeField] private AudioObject pickUp = new AudioObject(AudioType.PickUp, null);

}