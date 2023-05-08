using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptableMapChanging : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private MapDisplay mapdisplay;
    private int currentindex;

    private void Awake()
    {
        mapdisplay.DisplayMap((Map)scriptableObjects[0]);
    }
    public void ChangeMapIndex(int change)
    {
        currentindex += change;

        if (currentindex < 0)
        {
            currentindex = scriptableObjects.Length - 1;
        }
        else if(currentindex > scriptableObjects.Length - 1)
        {
            currentindex = 0;
        }
        if(mapdisplay != null)
        {
            mapdisplay.DisplayMap((Map)scriptableObjects[currentindex]);
        }
    }
    public void ChangeMap()
    {
        SceneManager.LoadScene(mapdisplay.MapName.text);
    }
}
