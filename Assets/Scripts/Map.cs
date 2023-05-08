using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Map",menuName = "ScriptableObjects/Map")]
public class Map : ScriptableObject 
{
    public int mapindex;
    public string mapname;
    public Sprite mapimage;
}
