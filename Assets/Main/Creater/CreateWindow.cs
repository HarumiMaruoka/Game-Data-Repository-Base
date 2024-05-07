using System;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Lion
{
    public class CreateWindow : EditorWindow
    {
        [MenuItem("Window/Repository Create Window")]
        static void Init()
        {
            GetWindow(typeof(CreateWindow)).Show();
        }


        private string _common;
        private static string _dataName = "Data";
        private static string _dataRepositoryName = "DataRepository";
        private static string _windowLayout = "RepositoryWindowLayout";
        private static string _windowName = "DataWindow";
        private static string _path;

        private static string _createFlagKey = "CreateFlag";
        private static string _pathKey = "AssetPath";
        private static string _repositoryNameKey = "RepositoryName";

        private void OnEnable()
        {
            _dataName = "Data";
            _dataRepositoryName = "DataRepository";
            _windowLayout = "RepositoryWindowLayout";
            _windowName = "DataWindow";
        }

        private void OnGUI()
        {
            // タイトル
            EditorGUILayout.LabelField("Data Repository Create Window");
            // CommonValue入力
            InputCommonValue();
            // DataName入力フィールド
            InputFileName("Data Name: ", ref _dataName);
            // RepositoryName入力フィールド
            InputFileName("Repository Name: ", ref _dataRepositoryName);
            // WindowLayout入力フィールド
            InputFileName("Window Layout: ", ref _windowLayout);
            // WindowName入力フィールド
            InputFileName("Window Name: ", ref _windowName);
            // Path入力フィールド
            InputPath();
            // Createフィールド
            InputCreateButton();
        }

        private void InputCommonValue()
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Common", GUILayout.Width(108f));

            var emptyLabel = new GUIContent();
            var old = _common;
            _common = EditorGUILayout.TextField(emptyLabel, _common, GUILayout.Width(220f));
            if (old != _common)
            {
                _dataName = _common + "Data";
                _dataRepositoryName = _common + "DataRepository";
                _windowLayout = _common + "RepositoryWindowLayout";
                _windowName = _common + "DataWindow";
                _path = _common;
            }

            EditorGUILayout.EndHorizontal();
        }

        private void InputFileName(string label, ref string fileName)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(label, GUILayout.Width(108f));

            var emptyLabel = new GUIContent();
            fileName = EditorGUILayout.TextField(emptyLabel, fileName, GUILayout.Width(220f));

            EditorGUILayout.LabelField(".cs", GUILayout.Width(50f));

            EditorGUILayout.EndHorizontal();
        }

        private void InputPath()
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField($"Path: {Application.dataPath}/");
            _path = EditorGUILayout.TextField(new GUIContent(), _path);

            EditorGUILayout.EndHorizontal();
        }

        private string AdjustedDataPath => Application.dataPath + "\\" + _path + $"\\{_dataName}.cs";
        private string AdjustedRepositoryPath => Application.dataPath + "\\" + _path + $"\\{_dataRepositoryName}.cs";
        private string AdjustedLayoutPath => Application.dataPath + "\\" + _path + $"\\{_windowLayout}.cs";
        private string AdjustedWindowPath => Application.dataPath + "\\" + _path + $"\\{_windowName}.cs";

        private void InputCreateButton()
        {
            if (GUILayout.Button("Create"))
            {
                // Create DataName.cs file.
                FileCreator.CreateCSharpFile(AdjustedDataPath, FileTemplate.Data(_dataName));
                // Create RepositoryName.cs file.
                FileCreator.CreateCSharpFile(AdjustedRepositoryPath, FileTemplate.DataRepository(_dataRepositoryName, _dataName));
                // Create WindowLayout.cs file.
                FileCreator.CreateCSharpFile(AdjustedLayoutPath, FileTemplate.WindowLayout(_windowLayout, _dataName));
                // Create WindowName.cs file.
                FileCreator.CreateCSharpFile(AdjustedWindowPath, FileTemplate.Window(_windowName, _dataName, _windowLayout));

                // Save
                EditorPrefs.SetBool(_createFlagKey, true);
                EditorPrefs.SetString(_pathKey, _path);
                EditorPrefs.SetString(_repositoryNameKey, _dataRepositoryName);

                AssetDatabase.Refresh();
                Close();
            }
        }

        [DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            if (EditorPrefs.GetBool(_createFlagKey))
            {
                EditorPrefs.SetBool(_createFlagKey, false);
                var repositoryName = EditorPrefs.GetString(_repositoryNameKey);
                var path = Path.Combine("Assets", EditorPrefs.GetString(_pathKey));

                var instance = ScriptableObject.CreateInstance(repositoryName);

                var fileName = repositoryName + ".asset";
                if (instance) AssetDatabase.CreateAsset(instance, Path.Combine(path, fileName));
            }
        }
    }
}