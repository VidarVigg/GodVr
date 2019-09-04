using UnityEngine;

[CreateAssetMenu(fileName = "Game Set", menuName = "Audio Set/Game")]
public class GameAudioSet : ScriptableObject
{

    #region Fields

    [SerializeField]
    private GameAudioObject[] gameAudioObject = new GameAudioObject[]
    {
        new GameAudioObject(GameAudioType.PickUp, null),
        new GameAudioObject(GameAudioType.PutDown, null),
        new GameAudioObject(GameAudioType.PickUp, null),

    };

    #endregion

    #region Properties

    public GameAudioObject[] GameAudioObject
    {
        get { return gameAudioObject; }
    }

    #endregion

}