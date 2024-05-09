using System;
using UnityEngine;

public class TestData : ScriptableObject
{
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public float AttackPower { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}