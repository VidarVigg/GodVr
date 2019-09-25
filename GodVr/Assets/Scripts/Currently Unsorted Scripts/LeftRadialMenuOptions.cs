using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeftRadialMenuOptions : MonoBehaviour
{

    #region Debug Methods
    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void LogDebugLog()
    {
        Debug.Log("Debug_Clicked");
    }
    #endregion
}
