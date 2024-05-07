using System;
using UnityEditor;
using UnityEngine;

namespace Lion
{
    [CreateAssetMenu(
        fileName = "SampleDataRepository",
        menuName = "Game Data Repository/SampleDataRepository")]
    public class SampleDataRepository : RepositoryBase<SampleData> { }
}