using UnityEngine;

[CreateAssetMenu(fileName = "Menu Set", menuName = "Audio Set/Menu")]
public class MenuAudioSet : ScriptableObject
{

    #region Fields

    [SerializeField] private MenuAudioObject[] menuAudioObjecs = new MenuAudioObject[] 
    {

        new MenuAudioObject(MenuAudioType.Select, null),

    };

    #endregion

    #region Properties

    public MenuAudioObject[] MenuAudioObjects { get { return menuAudioObjecs; } }

    #endregion

}