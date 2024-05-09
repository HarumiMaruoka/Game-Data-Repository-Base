using System;
using UnityEngine;

public static class FileTemplate
{
    public static string Data(string dataName) =>
        $"using System;                              \r\n" +
        $"using UnityEngine;                         \r\n" +
        $"                                           \r\n" +
        $"public class {dataName} : ScriptableObject \r\n" +
        $"{{                                         \r\n" +
        $"                                           \r\n" +
        $"}}                                         ";

    public static string Sheet(string sheetName, string dataName) =>
        $"using System;                                               \r\n" +
        $"using UnityEngine;                                          \r\n" +
        $"                                                            \r\n" +
        $"[CreateAssetMenu(                                           \r\n" +
        $"    fileName = \"{sheetName}\",                             \r\n" +
        $"    menuName = \"Game Data Sheet/{sheetName}\")]            \r\n" +
        $"public class {sheetName} : Lion.SheetBase<{dataName}> {{ }} ";

    public static string WindowLayout(string layoutName, string dataName) =>
        $"#if UNITY_EDITOR                                                \r\n" +
        $"using System;                                                   \r\n" +
        $"using UnityEngine;                                              \r\n" +
        $"                                                                \r\n" +
        $"public class {layoutName} : Lion.WindowLayout<{dataName}> {{ }} \r\n" +
        $"#endif                                                          ";

    public static string Window(string windowName, string dataName, string sheetName, string layoutName) =>
        $"#if UNITY_EDITOR                                                                        \r\n" +
        $"using System;                                                                           \r\n" +
        $"using UnityEditor;                                                                      \r\n" +
        $"using UnityEngine;                                                                      \r\n" +
        $"                                                                                        \r\n" +
        $"public class {windowName} : Lion.SheetWindowBase<{dataName}, {sheetName}, {layoutName}> \r\n" +
        $"{{                                                                                      \r\n" +
        $"    [MenuItem(\"Window/Game Data Sheet/{windowName}\")]                                 \r\n" +
        $"    static void Init()                                                                  \r\n" +
        $"    {{                                                                                  \r\n" +
        $"        GetWindow(typeof({windowName})).Show();                                         \r\n" +
        $"    }}                                                                                  \r\n" +
        $"}}                                                                                      \r\n" +
        $"#endif                                                                                  ";
}