//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(MenuAudioSet))]
//public class MenuSetEditor : Editor
//{

//    public override void OnInspectorGUI()
//    {

//        MenuAudioSet gas = (MenuAudioSet)target;

//        for (int i = 0; i < gas.MenuAudioObjects.Length; i++)
//        {
//            EditorGUILayout.ObjectField(gas.MenuAudioObjects[i].MenuAudioType.ToString(), gas.MenuAudioObjects[i].AudioClip, typeof(AudioClip), allowSceneObjects: true);
//        }

//    }

//}