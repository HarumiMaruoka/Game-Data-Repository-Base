using System;
using UnityEngine;

public class Test4Data : ScriptableObject
{
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public float AttackPower { get; private set; }
}
