using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameAudioSet))]
public class GameSetEditor : Editor
{

    public override void OnInspectorGUI()
    {

        GameAudioSet gas = (GameAudioSet)target;

        for (int i = 0; i < gas.AudioObjects.Length; i++)
        {
            EditorGUILayout.ObjectField(gas.AudioObjects[i].AudioType.ToString(), gas.AudioObjects[i].AudioClip, typeof(AudioClip), allowSceneObjects: true);
        }

    }

}