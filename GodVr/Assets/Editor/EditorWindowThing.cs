using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorWindowExample : EditorWindow
{
    //#u translates to "shift + u" which has been the keyboard shortcut bound to this window
    //It can otherwise be found under "Anton/EditorWindowExample" in the regular row of menus
    private const string shortcut = " #u";
    private const string menuPath = "Anton/" + nameof(EditorWindowExample) + shortcut;

    //Used to restore labelwidth throughout the OnGui method
    private readonly float originalLabelWidth = EditorGUIUtility.labelWidth;

    //Used to store and handle variables related to the intended script functions
    public bool xRot = true, yRot = true, zRot = true;
    public float rotationOffset;

    public GameObject lookAtObject;

    [MenuItem(menuPath)]

    public static void SetupWindow()
    {
        var window = GetWindow<EditorWindowExample>();
        window.minSize = new Vector2(350, 200);
        window.maxSize = new Vector2(window.minSize.x + 100, window.minSize.y + 100);
    }

    //So I can press Escape to clear selection or close the window altogether
    private void HandleInput()
    {
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
        {
            if (Selection.objects.Length >= 1)
            {
                Selection.objects = null;
            }
            else
            {
                this.Close();
            }
        }
    }

    private void OnGUI()
    {
        HandleInput();

        //Trams
        GUILayout.BeginVertical(GUI.skin.box);
        var backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.red;
        var test = new GUIStyle(EditorStyles.toolbarButton);
        test.fontSize = 5;
        EditorGUILayout.LabelField("murder", test);
        GUI.backgroundColor = backgroundColor;
        //EndTrams

        EditorGUILayout.Space();

        //A set of bools for selecting which axis I wish to rotate the selection of gameobjects around
        EditorGUILayout.LabelField("Select axis' to rotate around");
        GUILayout.BeginHorizontal(GUI.skin.box);
        EditorGUIUtility.labelWidth = CalculateLabelWidth(nameof(xRot));
        xRot = EditorGUILayout.Toggle(label: nameof(xRot), xRot);
        yRot = EditorGUILayout.Toggle(label: nameof(yRot), yRot);
        zRot = EditorGUILayout.Toggle(label: nameof(zRot), zRot);
        EditorGUIUtility.labelWidth = originalLabelWidth;
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Using a slider to select the max angle I want to have stuff rotated to
        EditorGUILayout.LabelField("Select rotation offset limit");
        GUILayout.BeginVertical(GUI.skin.box);
        rotationOffset = EditorGUILayout.Slider(rotationOffset, 0, 180);
        GUILayout.EndVertical();

        EditorGUILayout.Space();

        //If the rotate button is pressed without having the proper parameters provided, a dialogue box appears
        if (GUILayout.Button($"Apply random rotation to {Selection.gameObjects.Length} objects"))
        {
            if (!xRot && !yRot && !zRot || Selection.gameObjects.Length == 0)
            {
                EditorUtility.DisplayDialog("FATAL ERROR", "Pls check at least one box and select at least 1 object.", " :)))) ");
                return;
            }
            Rotate(Selection.gameObjects, rotationOffset, xRot, yRot, zRot);
        }

        //Resets transforms
        if (GUILayout.Button("Reset Transforms"))
        {
            if (Selection.gameObjects.Length != 0)
            {
                ResetRotation(Selection.gameObjects);
            }
        }


        GUILayout.EndVertical();

        GUILayout.BeginVertical(GUI.skin.box);

        if (GUILayout.Button("Send Item To Ground"))
        {
            if (Selection.gameObjects.Length != 0)
            {
                SendToGround(Selection.gameObjects);
            }
        }
        GUILayout.EndVertical();


        GUILayout.BeginVertical(GUI.skin.box);

        lookAtObject = (GameObject)EditorGUILayout.ObjectField(lookAtObject, typeof(GameObject), true);

        if (GUILayout.Button("LookAt"))
        {
            if (Selection.gameObjects.Length != 0)
            {
                LookAtObject(Selection.gameObjects);
            }
        }


        GUILayout.EndVertical();
    }

    //It does... things
    public static float CalculateLabelWidth(GUIContent label, float padding = 0.0f)
    {
        float labelwidth = GUI.skin.label.CalcSize(label).x + padding;
        return labelwidth;
    }

    //This one too
    public static float CalculateLabelWidth(string label, float padding = 0.0f)
    {
        return CalculateLabelWidth(new GUIContent(label));
    }

    //Applies the actual rotation for each object in the selection array
    private void Rotate(GameObject[] transforms, float offsetMax, bool xRot = false, bool yRot = false, bool zRot = false)
    {
        foreach (GameObject gameObject in transforms)
        {
            var vector = gameObject.transform.localEulerAngles;
            if (xRot)
                vector.x = Random.Range(-offsetMax, offsetMax);
            if (yRot)
                vector.y = Random.Range(-offsetMax, offsetMax);
            if (zRot)
                vector.z = Random.Range(-offsetMax, offsetMax);

            Undo.RecordObject(gameObject.transform, "Rotation applied");
            gameObject.transform.localEulerAngles = vector;
        }
    }

    //Same but with transforms
    private void ResetRotation(GameObject[] transforms)
    {
        foreach (GameObject obj in transforms)
        {
            obj.transform.localEulerAngles = Vector3.zero;
        }
    }

    private void SendToGround(GameObject[] transforms)
    {
        Debug.Log("Sending to ground");

        foreach (GameObject obj in transforms)
        {
            Ray ray = new Ray(obj.transform.position, Vector3.down);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);

            if (hitInfo.distance < 100.0f)
            {
                Undo.RecordObject(obj.transform, "Sent object(s) to ground");
                obj.transform.position = hitInfo.point;

                if (obj.transform.position == Vector3.zero)
                {
                    Debug.Log(obj.transform.name + "was placed out of bounds, now at 0,0,0");
                }
            }
        }
    }

    private void LookAtObject(GameObject[] transforms)
    {

        if (lookAtObject)
        {
            foreach (GameObject obj in transforms)
            {
                Undo.RecordObject(obj.transform, "LookAt");
                obj.transform.LookAt(lookAtObject.transform.position);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Oh Dear", " ", "Sssnnnniiiiifffffff");
        }
    }
}
