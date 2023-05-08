using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] public Text MapName;
    [SerializeField] public Image MapImage;
   public void DisplayMap(Map map)
    {
        MapName.text = map.mapname;
        MapImage.sprite = map.mapimage;
    }
}
