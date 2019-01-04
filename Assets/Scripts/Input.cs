using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input : MonoBehaviour
{
    public Image pic;
    public Text letter;

    public Database db;
    
    void OnGUI()
    {
        if (!UnityEngine.Input.anyKeyDown) return;
        
        var e = Event.current;
        if (e.type != EventType.KeyDown) return;

        ApplyKeyDown(e);
    }

    private void ApplyKeyDown(Event e)
    {
        var t = db.GetSample(e.keyCode);

        if (t == null) return;

        pic.sprite = t.picture;
        letter.text = t.text;
    }
}
