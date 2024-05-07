using System;
using UnityEngine;
using UnityEditor;

namespace Lion
{
    public class PathFinder : MonoBehaviour
    {
        public static string GetProjectPath()
        {
            return Application.dataPath;
        }
    }
}