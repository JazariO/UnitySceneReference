using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class SceneReference
{
    [SerializeField] private string sceneGuid;
    [SerializeField] private string sceneName;

    public string SceneName
    {
        get { return sceneName; }
    }

#if UNITY_EDITOR
    public string ScenePath
    {
        get { return AssetDatabase.GUIDToAssetPath(sceneGuid); }
    }
#endif
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SceneReference))]
public class SceneReferenceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty sceneGuidProp = property.FindPropertyRelative("sceneGuid");
        SerializedProperty sceneNameProp = property.FindPropertyRelative("sceneName");

        SceneAsset sceneObject = null;
        if (!string.IsNullOrEmpty(sceneGuidProp.stringValue))
        {
            string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuidProp.stringValue);
            sceneObject = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        }

        EditorGUI.BeginChangeCheck();
        sceneObject = EditorGUI.ObjectField(position, label, sceneObject, typeof(SceneAsset), false) as SceneAsset;

        if (EditorGUI.EndChangeCheck())
        {
            if (sceneObject != null)
            {
                string scenePath = AssetDatabase.GetAssetPath(sceneObject);
                sceneGuidProp.stringValue = AssetDatabase.AssetPathToGUID(scenePath);
                sceneNameProp.stringValue = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            } else
            {
                sceneGuidProp.stringValue = string.Empty;
                sceneNameProp.stringValue = string.Empty;
            }
        }

        EditorGUI.EndProperty();
    }
}
#endif