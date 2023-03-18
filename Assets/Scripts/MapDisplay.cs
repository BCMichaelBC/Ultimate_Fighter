using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Text MapName;
    [SerializeField] private Image MapImage;
    [SerializeField] private Button playbutton;
   public void DisplayMap(Map map)
    {
        MapName.text = map.mapname;
        MapImage.sprite = map.mapimage;
        playbutton.onClick.AddListener(() => SceneManager.LoadScene(map.scenetoload.name));
    }
}
