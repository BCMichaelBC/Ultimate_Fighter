using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI TimerText;
    [SerializeField] public float LevelTime = 90; //starting time 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelTime > 0)
        {
            LevelTime -= Time.deltaTime;
        }
        TimerText.text = Mathf.Round(LevelTime).ToString();
    }
}
