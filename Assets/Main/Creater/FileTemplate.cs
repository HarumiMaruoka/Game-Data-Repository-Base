using System;
using UnityEngine;

public static class FileTemplate
{
    public static string Data(string dataName) =>
       $"using System;                                    \r\n" +
       $"using UnityEngine;                               \r\n" +
       $"                                                 \r\n" +
       $"public class {dataName} : ScriptableObject {{ }} \r\n";

    public static string DataRepository(string repositoryName, string dataName) =>
        $"using System;                                                         \r\n" +
        $"using UnityEngine;                                                    \r\n" +
        $"                                                                      \r\n" +
        $"[CreateAssetMenu(                                                     \r\n" +
        $"    fileName = \"{repositoryName}\",                                  \r\n" +
        $"    menuName = \"Game Data Repository/{repositoryName}\")]            \r\n" +
        $"public class {repositoryName} : Lion.RepositoryBase<{dataName}> {{ }} \r\n";

    public static string WindowLayout(string layoutName, string dataName) =>
        $"#if UNITY_EDITOR                                                \r\n" +
        $"using System;                                                   \r\n" +
        $"using UnityEngine;                                              \r\n" +
        $"                                                                \r\n" +
        $"public class {layoutName} : Lion.WindowLayout<{dataName}> {{ }} \r\n" +
        $"#endif                                                          \r\n";

    public static string Window(string windowName, string dataName,string repositoryName, string layoutName) =>
        $"#if UNITY_EDITOR                                                                                  \r\n" +
        $"using System;                                                                                     \r\n" +
        $"using UnityEditor;                                                                                \r\n" +
        $"using UnityEngine;                                                                                \r\n" +
        $"                                                                                                  \r\n" +
        $"public class {windowName} : Lion.RepositoryWindowBase<{dataName}, {repositoryName}, {layoutName}> \r\n" +
        $"{{                                                                                                \r\n" +
        $"    [MenuItem(\"Window/Game Data Repository/{windowName}\")]                                      \r\n" +
        $"    static void Init()                                                                            \r\n" +
        $"    {{                                                                                            \r\n" +
        $"        GetWindow(typeof({windowName})).Show();                                                   \r\n" +
        $"    }}                                                                                            \r\n" +
        $"}}                                                                                                \r\n" +
        $"#endif                                                                                            \r\n";
}