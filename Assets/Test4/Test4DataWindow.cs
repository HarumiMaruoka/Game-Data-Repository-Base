#if UNITY_EDITOR                                                                                  
using System;                                                                                     
using UnityEditor;                                                                                
using UnityEngine;                                                                                
                                                                                                  
public class Test4DataWindow : Lion.RepositoryWindowBase<Test4Data, Test4DataRepository, Test4RepositoryWindowLayout> 
{                                                                                                
    [MenuItem("Window/Game Data Repository/Test4DataWindow")]                                      
    static void Init()                                                                            
    {                                                                                            
        GetWindow(typeof(Test4DataWindow)).Show();                                                   
    }                                                                                            
}                                                                                                
#endif                                                                                            
