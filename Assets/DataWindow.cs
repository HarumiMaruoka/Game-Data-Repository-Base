#if UNITY_EDITOR                                                                
using System;                                                                   
using UnityEditor;                                                              
using UnityEngine;                                                              
                                                                                
public class DataWindow : Lion.RepositoryWindowBase<Data, RepositoryWindowLayout> 
{                                                                              
    [MenuItem("Window/DataWindow")]                                         
    static void Init()                                                          
    {                                                                          
        GetWindow(typeof(DataWindow)).Show();                                 
    }                                                                          
}                                                                              
#endif                                                                          
