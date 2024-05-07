#if UNITY_EDITOR                                                                
using System;
using UnityEditor;
using UnityEngine;

public class TestDataWindow : Lion.RepositoryWindowBase<TestData, TestDataRepository, TestRepositoryWindowLayout>
{
    [MenuItem("Window/TestDataWindow")]
    static void Init()
    {
        GetWindow(typeof(TestDataWindow)).Show();
    }
}
#endif
