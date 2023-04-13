using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SperidTopDownFramework.Editor
{
    public class SceneWindow : EditorWindow
    {
        private const string START_SCENE_PATH = "SceneWindow_StartScenePath";

        [MenuItem("SperidTopDownFramework/SceneWindow")]
        public static void Open()
        {
            var window = (SceneWindow)GetWindow(typeof(SceneWindow), false, "SceneWindow");
        }

        private void OnEnable()
        {
            string startScenePath = EditorUserSettings.GetConfigValue(START_SCENE_PATH);

            if (!string.IsNullOrEmpty(startScenePath))
            {
                SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(startScenePath);
                if (sceneAsset == null)
                {
                    Debug.LogWarning(string.Format("{0} is not found", startScenePath));
                }
                else
                {
                    EditorSceneManager.playModeStartScene = sceneAsset;
                }

            }
        }

        private void OnGUI()
        {
            var beforeScenePath = string.Empty;
            var afterScenePath = string.Empty;

            if (EditorSceneManager.playModeStartScene != null)
            {
                beforeScenePath = AssetDatabase.GetAssetPath(EditorSceneManager.playModeStartScene);
            }

            EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("Start Scene"), EditorSceneManager.playModeStartScene, typeof(SceneAsset), false);

            if (GUILayout.Button("Play"))
            {
                EditorApplication.ExecuteMenuItem("Edit/Play");
            }

            if (GUILayout.Button("Play Current Scene"))
            {
                EditorSceneManager.playModeStartScene = null;
                EditorApplication.ExecuteMenuItem("Edit/Play");
                return;
            }

            if (EditorSceneManager.playModeStartScene != null)
            {
                afterScenePath = AssetDatabase.GetAssetPath(EditorSceneManager.playModeStartScene);
            }

            if (beforeScenePath != afterScenePath)
            {
                EditorUserSettings.SetConfigValue(START_SCENE_PATH, afterScenePath);
            }
        }
    }

}
