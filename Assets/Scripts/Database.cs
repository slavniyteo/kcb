using System;
using System.Collections.Generic;
using OneLine;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Database", menuName = "Database")]
public class Database : ScriptableObject
{
    [SerializeField] private List<TargetVariants> list = new List<TargetVariants>();

    public Dictionary<KeyCode, TargetVariants> dict;

    private void OnEnable()
    {
        dict = new Dictionary<KeyCode, TargetVariants>(list.Count);
        foreach (var t in list)
        {
            dict[t.key] = t;
        }
    }

    public Target GetSample(KeyCode code)
    {
        TargetVariants list = null;
        if (!dict.TryGetValue(code, out list))
        {
            return null;
        }

        return list.Sample();
    }
    
}

[Serializable]
public class TargetVariants
{
    [SerializeField] public string letter;
    [SerializeField] public KeyCode key;
    [SerializeField, OneLine] public List<Target> list;

    public Target Sample()
    {
        if (list.Count == 0) return null;

        return list[Random.Range(0, list.Count)];
    }
}

[Serializable]
public class Target
{
    [SerializeField] public string text;
    [SerializeField] public Sprite picture;
}