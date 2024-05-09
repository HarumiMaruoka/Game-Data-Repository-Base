using System;
using UnityEngine;

public class SampleBehaviour : MonoBehaviour
{
    [SerializeField] private Test4DataRepository _test4DataRepository;
    [SerializeField] private SampleView _sampleView;

    private void Start()
    {
        foreach (var item in _test4DataRepository)
        {
            var instance = Instantiate(_sampleView, this.transform);
            instance.Initialize(item);
        }
    }
}