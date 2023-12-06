using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Thayane.Editor
{
    public class StartFromScene : EditorWindow
    {
        void OnGUI()
        {
            EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("Start Scene"), 
                EditorSceneManager.playModeStartScene, typeof(SceneAsset), false);

            var scenePath = "Assets/Scenes/Menu.unity";
            if (GUILayout.Button("Set start Scene: " + scenePath))
                SetPlayModeStartScene(scenePath);
        }

        void SetPlayModeStartScene(string scenePath)
        {
            SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
            if (myWantedStartScene != null) EditorSceneManager.playModeStartScene = myWantedStartScene;
            else Debug.Log("Could not find Scene " + scenePath);
        }

        [MenuItem("Thayane/Start From Scene")]
        static void Open()
        {
            GetWindow<StartFromScene>();
        }
    }
}
