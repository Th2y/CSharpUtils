using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Thayane.Editor
{
    public class DimensionChecker : EditorWindow
    {
        private readonly List<Texture2D> _nonMultipleOf4Textures = new();
        private Vector2 _scrollPosition;

        [MenuItem("Tools/Check Dimensions (Multiples of 4)")]
        private static void Init()
        {
            DimensionChecker window = (DimensionChecker)EditorWindow.GetWindow(typeof(DimensionChecker));
            window.Show();
            window.CheckDimensions();
        }

        private void OnGUI()
        {
            GUILayout.Label("Textures with Dimensions not a Multiple of 4", EditorStyles.boldLabel);

            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            foreach (Texture2D texture in _nonMultipleOf4Textures)
            {
                if (GUILayout.Button($"{texture.name} ({texture.width}x{texture.height})"))
                {
                    EditorGUIUtility.PingObject(texture);
                }
            }

            EditorGUILayout.EndScrollView();
        }

        private void CheckDimensions()
        {
            _nonMultipleOf4Textures.Clear();

            string folderPath = EditorUtility.OpenFolderPanel("Select Texture Folder", "Assets", "");

            if (!string.IsNullOrEmpty(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath, "*.png", SearchOption.AllDirectories);

                foreach (string filePath in files)
                {
                    string relativePath = "Assets" + filePath.Replace(Application.dataPath, "").Replace('\\', '/');
                    Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(relativePath);

                    if (texture != null)
                    {
                        int width = texture.width;
                        int height = texture.height;

                        if (width % 4 != 0 || height % 4 != 0)
                        {
                            _nonMultipleOf4Textures.Add(texture);
                        }
                    }
                }
            }

            Repaint();
        }
    }
}
