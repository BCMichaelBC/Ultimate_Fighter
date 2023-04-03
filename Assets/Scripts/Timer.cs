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

    public Player playerOne;
    public Player playerTwo;

    public Winner levelManager;
    public HealthBar playerOneHealth;
    public HealthBar playerTwoHealth;
    public StateManager playerOneState;
    public StateManager playerTwoState;


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

         else if(LevelTime <= 0)
         {
            if(playerOne.Hp > playerTwo.Hp)
            {
                print("Player One Wins");

                levelManager.playerOneWins++;
                if(levelManager.roundNumber == 1)
                {
                    levelManager.playerOneWinRoundOne.SetActive(true);
                }
                else if(levelManager.roundNumber >= 2)
                {
                    levelManager.playerOneWinRoundTwo.SetActive(true);
                }
                Reset();
            }
            else if(playerTwo.Hp > playerOne.Hp)
            {
                print("Player Two Wins");
                levelManager.playerTwoWins++;
                if(levelManager.roundNumber == 1)
                {
                    levelManager.playerTwoWinRoundOne.SetActive(true);
                }
                else if(levelManager.roundNumber >= 2)
                {
                    levelManager.playerTwoWinRoundTwo.SetActive(true);
                }
                Reset();
            }
            else if(playerTwo.Hp == playerOne.Hp)
            {
                print("Draw");
            }
         }
    }

    void Reset()
    {
        playerOne.CheckWinner();
            playerOne.Hp = 100;
            playerTwo.Hp = 100;
            playerOneState.health = 100;
            playerTwoState.health = 100;
            playerOneHealth.UpdateHpBar();
            playerTwoHealth.UpdateHpBar();
            LevelTime = 90;
            TimerText.text = Mathf.Round(LevelTime).ToString();
            playerOne.transform.position = new Vector3(-6f, -1f, 0f);
            playerTwo.transform.position = new Vector3(6f, -1f, 0f);
    }

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
