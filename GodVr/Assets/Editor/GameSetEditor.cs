//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(GameAudioSet))]
//public class GameSetEditor : Editor
//{

//    public override void OnInspectorGUI()
//    {

//        GameAudioSet gas = (GameAudioSet)target;

//        for (int i = 0; i < gas.GameAudioObject.Length; i++)
//        {
//            EditorGUILayout.ObjectField(gas.GameAudioObject[i].GameAudioType.ToString(), gas.GameAudioObject[i].AudioClip, typeof(AudioClip), allowSceneObjects: true);
//        }

//    }

//}