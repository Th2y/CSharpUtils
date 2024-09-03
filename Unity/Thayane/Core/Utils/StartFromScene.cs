#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class StartFromScene : EditorWindow
{
    private const string _startSceneKey = "StartFromScenePath";
    private static string _scenePath;

    static StartFromScene()
    {
        _scenePath = EditorPrefs.GetString(_startSceneKey);
        if (_scenePath != null)
        {
            EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(_scenePath);
        }
    }

    void OnGUI()
    {
        SceneAsset newStartScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("Start Scene"),
            AssetDatabase.LoadAssetAtPath<SceneAsset>(_scenePath), typeof(SceneAsset), false);

        if (newStartScene != null && newStartScene != EditorSceneManager.playModeStartScene)
        {
            _scenePath = AssetDatabase.GetAssetPath(newStartScene);
            SetPlayModeStartScene(_scenePath);
        }

        if (GUILayout.Button("Set start Scene: " + _scenePath))
        {
            SetPlayModeStartScene(_scenePath);
        }

        if (GUILayout.Button("Set Default Scene: Assets/Scenes/LoginUI.unity"))
        {
            _scenePath = "Assets/Scenes/LoginUI.unity";
            SetPlayModeStartScene(_scenePath);
        }

        if (GUILayout.Button("Remove Default Scene"))
        {
            _scenePath = null;
            EditorSceneManager.playModeStartScene = null;
            EditorPrefs.DeleteKey(_startSceneKey);
        }
    }

    private void SetPlayModeStartScene(string scenePath)
    {
        SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        if (myWantedStartScene != null)
        {
            EditorSceneManager.playModeStartScene = myWantedStartScene;
            EditorPrefs.SetString(_startSceneKey, scenePath);
        }
        else
        {
            Debug.Log("Could not find Scene " + scenePath);
        }
    }

    [MenuItem("Utils/Start From Scene")]
    static void Open()
    {
        GetWindow<StartFromScene>();
    }
}
#endif
