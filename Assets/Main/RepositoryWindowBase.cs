#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Lion
{
    public class RepositoryWindowBase<DataType, RepositoryType, WindowLayoutType> : EditorWindow
        where DataType : ScriptableObject
        where RepositoryType : RepositoryBase<DataType>
        where WindowLayoutType : WindowLayout<DataType>
    {
        private RepositoryBase<DataType> _dataRepository;
        private Vector2 _scrollPosition;
        private bool _isSettingMode = false;

        private void OnEnable()
        {
            _dataRepository = AssetFinder.FindAssetsByType<RepositoryType>();

            Undo.undoRedoPerformed += () =>
            {
                Show();
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            };
        }

        void OnGUI()
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            _dataRepository = EditorGUILayout.ObjectField("Target", _dataRepository, typeof(RepositoryType), false) as RepositoryType;
            if (_dataRepository)
            {
                if (!_dataRepository.WindowLayout)
                {
                    _dataRepository.WindowLayout = ScriptableObject.CreateInstance<WindowLayoutType>();
                    _dataRepository.WindowLayout.Repository = _dataRepository;
                    AssetDatabase.AddObjectToAsset(_dataRepository.WindowLayout, _dataRepository);
                    EditorUtility.SetDirty(_dataRepository.WindowLayout);
                    AssetDatabase.SaveAssets();
                    _dataRepository.WindowLayout.name = "LayoutData";
                }

                _dataRepository.WindowLayout.DrawElements();

                if (GUILayout.Button("Create")) _dataRepository.Create();

                _dataRepository.WindowLayout.DrawGridLines();

                if (_isSettingMode = EditorGUILayout.Foldout(_isSettingMode, "Layout Settings"))
                {
                    _dataRepository.WindowLayout.DrawValueFields();
                }
            }

            EditorGUILayout.EndScrollView();
        }
    }
}
#endif