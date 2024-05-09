#if UNITY_EDITOR                                                                                  
using System;                                                                                     
using UnityEditor;                                                                                
using UnityEngine;                                                                                
                                                                                                  
public class Test5DataWindow : Lion.RepositoryWindowBase<Test5Data, Test5DataRepository, Test5RepositoryWindowLayout> 
{                                                                                                
    [MenuItem("Window/Game Data Repository/Test5DataWindow")]                                      
    static void Init()                                                                            
    {                                                                                            
        GetWindow(typeof(Test5DataWindow)).Show();                                                   
    }                                                                                            
}                                                                                                
#endif                                                                                            
