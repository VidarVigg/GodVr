using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GroundItemScript))]
[CanEditMultipleObjects]
public class GroundItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GroundItemScript script = (GroundItemScript)target;
        if (GUILayout.Button("Ground Object"))
        {
            script.DropChildObjects();
        }

        if (GUILayout.Button("Undo Ground"))
        {
            script.Undo();
        }
    }


}
