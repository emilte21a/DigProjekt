using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "new scrap", menuName = "Items/Scrap", order = 1)]
public class Scrap : Item
{
    public GameObject prefab;
    public int sellValue;
}
