using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Database", menuName="Database")]
public class Database : ScriptableObject
{
    [SerializeField] private List<Target> list = new List<Target>();

    public Dictionary<KeyCode, Target> dict;

    private void OnEnable()
    {
        dict = new Dictionary<KeyCode, Target>(list.Count);
        foreach (var t in list)
        {
            dict[t.key] = t;
        }
    }
}

[Serializable]
public class Target
{
    public KeyCode key;
    public string text;
    public Sprite picture;
}