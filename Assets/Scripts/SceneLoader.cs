using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public TMP_InputField name1;
    public TMP_InputField name2;
    public UIName NameScript;
    public void LoadScene(string SceneName)
    {
        NameScript.p1Name = name1.text;
        NameScript.p2Name = name2.text;
        
        SceneManager.LoadScene(SceneName);
    }
    void Start(){
        NameScript = GameObject.Find("GameManager").GetComponent<UIName>();
    }
}
