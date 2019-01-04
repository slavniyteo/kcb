using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using OneLine;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Random = UnityEngine.Random;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Database", menuName = "Database")]
public class Database : ScriptableObject
{
    [SerializeField, OneLine, HideLabel] private List<TargetVariants> list = new List<TargetVariants>();

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

#if UNITY_EDITOR
    [ContextMenu("InitializeAlphabet")]
    public void InitializeAlphabet()
    {
        list = new List<TargetVariants>();

        for (int i = 97; i <= 122; i++)
        {
            var targets = new TargetVariants();
            targets.key = (KeyCode) i;
            
            list.Add(targets);
        }
        EditorUtility.SetDirty(this);
    }
#endif
}

[Serializable]
public class TargetVariants
{
    [SerializeField, Width(50)] public KeyCode key;
    [SerializeField] public List<Target> list;

    public Target Sample()
    {
        if (list.Count == 0) return null;

        return list[Random.Range(0, list.Count)];
    }
}

[Serializable]
public class Target
{
    [SerializeField, Width(30)] public string letter;
    [SerializeField, Width(100)] public string text;
    [SerializeField, Width(50)] public Sprite picture;
}