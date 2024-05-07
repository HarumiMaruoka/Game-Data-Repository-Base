#if UNITY_EDITOR                                                                                  
using System;                                                                                     
using UnityEditor;                                                                                
using UnityEngine;                                                                                
                                                                                                  
public class Test2DataWindow : Lion.RepositoryWindowBase<Test2Data, Test2DataRepository, Test2RepositoryWindowLayout> 
{                                                                                                
    [MenuItem("Window/Game Data Repository/Test2DataWindow")]                                      
    static void Init()                                                                            
    {                                                                                            
        GetWindow(typeof(Test2DataWindow)).Show();                                                   
    }                                                                                            
}                                                                                                
#endif                                                                                            
