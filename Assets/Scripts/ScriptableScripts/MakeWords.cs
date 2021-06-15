using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeWords : MonoBehaviour

{
    [MenuItem("Assets/Create/My Scriptable Object")]
    public static void CreateMyAsset()
    {
        Words word = ScriptableObject.CreateInstance<Words>();

        

        AssetDatabase.CreateAsset(word, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = word;
    }
}

