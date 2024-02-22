using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Item : ScriptableObject
{
    public string name;
    public Sprite icon;
    public int stack;

    public virtual void Use()
    {
        Debug.Log(name + " was used");
    }


}
