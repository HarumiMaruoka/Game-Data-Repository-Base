#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

public class TestDataWindow : Lion.SheetWindowBase<TestData, TestSheet, TestSheetWindowLayout>
{
    [MenuItem("Window/Game Data Sheet/TestDataWindow")]
    static void Init()
    {
        GetWindow(typeof(TestDataWindow)).Show();
    }
}
#endif