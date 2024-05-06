using System;
using UnityEditor;
using UnityEngine;

namespace Lion
{
    public class SampleRepositoryWindow : RepositoryWindowBase<SampleData, SampleDataWindowLayout>
    {
        [MenuItem("Window/Sample Repository Window")]
        static void Init()
        {
            GetWindow(typeof(SampleRepositoryWindow)).Show();
        }
    }
}