using System;
using UnityEngine;
using UnityEngine.UI;

public class SampleView : MonoBehaviour
{
    [SerializeField]
    private Text _id;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _attackPower;

    public void Initialize(Test4Data data)
    {
        _id.text = data.ID.ToString();
        _image.sprite = data.Sprite;
        _attackPower.text = data.AttackPower.ToString();
    }
}