using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI TimerText;
    [SerializeField] public float LevelTime = 90; //starting time 
    [SerializeField] public GameObject PausePanel;
    [SerializeField] public bool GamePaused = false;

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

         if (Input.GetKeyDown(KeyCode.P))
         {
             if (GamePaused)
             {
                 ResumeGame();
             }
             else
             {
                 PauseGame();
             }
         }
    }

    // void FixedUpdate()
    // {

    //     if(GamePaused)
    //     {
    //         PauseGame();
    //     }
    //     else
    //     {
    //         ResumeGame();
    //     }

    // }

    void PauseGame()
    {
        GamePaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        GamePaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
