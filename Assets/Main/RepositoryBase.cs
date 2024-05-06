using System;
using System.Collections.Generic;
using UnityEditor;

#if UNITY_EDITOR
using UnityEngine;
#endif

namespace Lion
{
    public class RepositoryBase<T> : ScriptableObject where T : ScriptableObject
    {
        [SerializeField]
        private List<T> _collection;
        public IReadOnlyList<T> Collection => _collection;

        [HideInInspector]
        [SerializeField]
        public Lion.WindowLayout<T> WindowLayout;

        public T Create()
        {
            var instance = CreateInstance<T>();

#if UNITY_EDITOR
            Undo.RegisterCreatedObjectUndo(instance, "Create Character");
            Undo.RecordObject(this, "Create Character");
#endif

            _collection.Add(instance);
            instance.name = ToString();

#if UNITY_EDITOR
            AssetDatabase.AddObjectToAsset(instance, this);
            Undo.RecordObject(instance, "Create Character");
            Undo.RegisterCreatedObjectUndo(instance, "Create Character");

            EditorUtility.SetDirty(this);
            EditorUtility.SetDirty(instance);
            AssetDatabase.SaveAssets();
#endif

            return instance;
        }

        public void Delete(T data)
        {
#if UNITY_EDITOR
            Undo.RecordObject(this, "Delete Character");
#endif

            _collection.Remove(data);

#if UNITY_EDITOR
            Undo.DestroyObjectImmediate(data);
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
#endif
        }
    }
}