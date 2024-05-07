#if UNITY_EDITOR                                                                                  
using System;                                                                                     
using UnityEditor;                                                                                
using UnityEngine;                                                                                
                                                                                                  
public class Test3DataWindow : Lion.RepositoryWindowBase<Test3Data, Test3DataRepository, Test3RepositoryWindowLayout> 
{                                                                                                
    [MenuItem("Window/Game Data Repository/Test3DataWindow")]                                      
    static void Init()                                                                            
    {                                                                                            
        GetWindow(typeof(Test3DataWindow)).Show();                                                   
    }                                                                                            
}                                                                                                
#endif                                                                                            
