using System;
using UnityEditor;
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

        private string _dataName = "Data";
        private string _dataRepositoryName = "DataRepository";
        private string _windowLayout = "RepositoryWindowLayout";
        private string _windowName = "DataWindow";
        private string _path;

        private void OnEnable()
        {
            _path = PathFinder.GetProjectPath();
        }

        private void OnGUI()
        {
            // �^�C�g��
            EditorGUILayout.LabelField("Data Repository Create Window");
            // DataName���̓t�B�[���h
            InputFileName("Data Name: ", ref _dataName);
            // RepositoryName���̓t�B�[���h
            InputFileName("Repository Name: ", ref _dataRepositoryName);
            // WindowLayout���̓t�B�[���h
            InputFileName("Window Layout: ", ref _windowLayout);
            // WindowName���̓t�B�[���h
            InputFileName("Window Name: ", ref _windowName);
            // Path���̓t�B�[���h
            InputPath();
            // Create�t�B�[���h
            InputCreateButton();
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

            EditorGUILayout.LabelField("Path: ", GUILayout.Width(108f));

            var emptyLabel = new GUIContent();
            _path = EditorGUILayout.TextField(emptyLabel, _path, GUILayout.Width(220f));

            EditorGUILayout.EndHorizontal();
        }

        private void InputCreateButton()
        {
            if (GUILayout.Button("Create"))
            {
                // Create DataName.cs file.
                FileCreator.CreateCSharpFile(_path + $"\\{_dataName}.cs", FileTemplate.Data(_dataName));
                // Create RepositoryName.cs file.
                FileCreator.CreateCSharpFile(_path + $"\\{_dataRepositoryName}.cs", FileTemplate.DataRepository(_dataRepositoryName, _dataName));
                // Create WindowLayout.cs file.
                FileCreator.CreateCSharpFile(_path + $"\\{_windowLayout}.cs", FileTemplate.WindowLayout(_windowLayout, _dataName));
                // Create WindowName.cs file.
                FileCreator.CreateCSharpFile(_path + $"\\{_windowName}.cs", FileTemplate.Window(_windowName, _dataName, _windowLayout));

                AssetDatabase.Refresh();
                Close();
            }
        }
    }
}