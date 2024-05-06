#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Lion
{
    public class WindowLayout<T> : ScriptableObject where T : ScriptableObject
    {
        [field: SerializeReference] public RepositoryBase<T> Repository { get; set; }

        [SerializeField] public List<float> HorizontalSpacings = new List<float>();
        [SerializeField] public List<float> VerticalSpacings = new List<float>();

        [SerializeField] public Color GridLineColor = new Color(0.5f, 0.5f, 0.5f, 0.3f);
        [SerializeField] public Vector2 GridSize = new Vector2(2.8f, 2f);
        [SerializeField] public Vector2 GridOffset = new Vector2(2f, 21f);

        // 指定間隔で水平方向に特定のSerializedObjectの要素を描画する。
        private void DrawElement(T element, float height)
        {
            var serializedElement = new SerializedObject(element);
            var heightOption = GUILayout.Height(height);

            var it = serializedElement.GetIterator();
            it.NextVisible(true);

            serializedElement.Update();
            int counter = 0;
            while (it.NextVisible(false))
            {
                if (counter == HorizontalSpacings.Count) HorizontalSpacings.Add(50f);
                var labelWidthOption = GUILayout.Width(HorizontalSpacings[counter]);
                counter++;

                EditorGUILayout.LabelField(it.displayName, labelWidthOption, heightOption);

                if (counter == HorizontalSpacings.Count) HorizontalSpacings.Add(50f);
                var valueWidthOption = GUILayout.Width(HorizontalSpacings[counter]);
                counter++;
                EditorGUILayout.PropertyField(it, new GUIContent(), true, valueWidthOption, heightOption);
            }
            serializedElement.ApplyModifiedProperties();
            if (GUILayout.Button("Delete")) Repository.Delete(element);
        }

        // 指定間隔で垂直方向にCollectionの要素を描画する。
        public void DrawElements()
        {
            for (int i = 0; i < Repository.Collection.Count; i++)
            {
                if (i == VerticalSpacings.Count) VerticalSpacings.Add(20f);

                EditorGUILayout.BeginHorizontal();
                DrawElement(Repository.Collection[i], VerticalSpacings[i]);
                EditorGUILayout.EndHorizontal();
            }
        }

        // グリッド状に、仕切り線を描画する。
        public void DrawGridLines()
        {
            Handles.BeginGUI();
            Handles.color = GridLineColor;

            DrawHorizontalLines();
            DrawVerticalLines();

            Handles.EndGUI();
        }

        private void DrawHorizontalLines()
        {
            var totalWidth = GridOffset.x;
            foreach (var width in HorizontalSpacings)
            {
                totalWidth += width + GridSize.x;
            }

            var y = GridOffset.y;
            Handles.DrawLine(new Vector2(GridOffset.x, y), new Vector2(totalWidth, y));

            for (int i = 0; i < VerticalSpacings.Count; i++)
            {
                y += VerticalSpacings[i] + GridSize.y;

                Handles.DrawLine(new Vector2(GridOffset.x, y), new Vector2(totalWidth, y));
            }
        }

        private void DrawVerticalLines()
        {
            var totalHeight = GridOffset.y;
            foreach (var height in VerticalSpacings)
            {
                totalHeight += height + GridSize.y;
            }

            var x = GridOffset.x;
            Handles.DrawLine(new Vector2(x, GridOffset.y), new Vector2(x, totalHeight));

            for (int i = 0; i < HorizontalSpacings.Count; i += 2)
            {
                x += HorizontalSpacings[i] + HorizontalSpacings[i + 1] + GridSize.x * 2f;
                Handles.DrawLine(new Vector2(x, GridOffset.y), new Vector2(x, totalHeight));
            }
        }

        private int ElementCount(SerializedObject serializedObject)
        {
            int count = 0;

            var it = serializedObject.GetIterator();
            it.NextVisible(true);
            while (it.NextVisible(false)) count++;

            return count;
        }

        public void DrawValueFields()
        {
            var a = new SerializedObject(this);

            a.Update();
            var b = a.FindProperty("HorizontalSpacings");
            for (int i = 0; i < b.arraySize; i++)
            {
                EditorGUILayout.PropertyField(b.GetArrayElementAtIndex(i));
            }

            var c = a.FindProperty("VerticalSpacings");
            for (int i = 0; i < c.arraySize; i++)
            {
                EditorGUILayout.PropertyField(c.GetArrayElementAtIndex(i));
            }

            EditorGUILayout.PropertyField(a.FindProperty("GridLineColor"));
            EditorGUILayout.PropertyField(a.FindProperty("GridSize"));
            EditorGUILayout.PropertyField(a.FindProperty("GridOffset"));

            a.ApplyModifiedProperties();
        }
    }
}
#endif