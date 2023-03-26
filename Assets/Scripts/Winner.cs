using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Winner : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public Timer gameTimer;

    public GameObject playerOne;
    public GameObject playerTwo;

    public GameObject playerOneWinRoundOne, playerOneLoseRoundOne, playerOneWinRoundTwo, playerOneLoseRoundTwo;
    public Image playerOneRoundOne, playerOneRoundTwo, playerTwoRoundOne, playerTwoRoundTwo, playerOneRoundThree, playerTwoRoundThree;
    public GameObject playerTwoWinRoundOne, playerTwoLoseRoundOne, playerTwoWinRoundTwo, playerTwoLoseRoundTwo;
    public bool isRoundTwo, gameComplete;
    public bool roundOnePlayerOneWin;
    public bool roundOnePlayerTwoWin;
    public bool roundTwoPlayerOneWin;
    public bool roundTwoPlayerTwoWin;
    public int playerOneWins;
    public int playerTwoWins;
    public int roundNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        //gameTimer = GetComponent<Timer>();
        
    }

    void nextRound()
    {
        playerOne.transform.position = new Vector3(-6f, -1f, 0f);
        playerTwo.transform.position = new Vector3(6f, -1f, 0f);
        gameTimer.LevelTime = 90;
        TimerText.text = Mathf.Round(gameTimer.LevelTime).ToString();

       // if(gameComplete)
       // {
            if(playerOneWins >= 2)
            {
                print("Player One Wins");
                ResetGame();
            }
            else if(playerTwoWins >= 2)
            {
                print("Player Two Wins");
                ResetGame();
            }
            else if(playerOneWins == 1 && playerTwoWins == 1)
            {
                print("Round 3");
            }
       // }
    }

    void ResetGame()
    {
        playerOne.transform.position = new Vector3(-6f, -1f, 0f);
        playerTwo.transform.position = new Vector3(6f, -1f, 0f);

        Time.timeScale = 0;
       // playerOneRoundOne.color = new Color(0f, 0f, 1f, 0f);
        //playerTwoRoundOne.color = new Color(0f, 0f, 1f, 0f);
        //playerOneRoundTwo.color = new Color(0f, 0f, 1f, 0f);
       // playerTwoRoundTwo.color = new Color(0f, 0f, 1f, 0f);
       // playerOneRoundThree.color = new Color(0f, 0f, 1f, 0f);
       // playerTwoRoundThree.color = new Color(0f, 0f, 1f, 0f);
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (roundNumber == 1)
            {
                playerOneRoundOne.color = new Color(0f, 1f, 0f, 1f);
                playerTwoRoundOne.color = new Color(1f, 0f, 0f, 1f);

                playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                gameTimer.LevelTime = 90;
                TimerText.text = Mathf.Round(gameTimer.LevelTime).ToString();

               // playerOneRoundOne.color = new Color(0f, 1f, 0f, 0f);
              //  playerOneRoundOne.color = new Color(0f, 1f, 0f, 0f);
               // playerOneRoundOne.SetActive(true);
                //playerTwoLoseRoundOne.SetActive(true);
                playerOneWins++;
                roundNumber++;
            }
            else if (roundNumber == 2)
            {
                playerOneRoundTwo.color = new Color(0f, 1f, 0f, 1f);
                playerTwoRoundTwo.color = new Color(1f, 0f, 0f, 1f);
               // playerOneRoundTwo.SetActive(true);
                //playerOneLoseRoundTwo.SetActive(true);
                playerOneWins++;
                roundNumber++;

                nextRound();
               // ResetGame();
            }
            else if (roundNumber == 3)
            {
                playerOneRoundThree.color = new Color(0f, 1f, 0f, 1f);
                playerTwoRoundThree.color = new Color(1f, 0f, 0f, 1f);
                //playerOneRoundThree.color = new Color(0f, 1f, 0f, 1f);
                //playerOneWinRoundTwo.SetActive(true);
                playerOneWins++;
                roundNumber++;

                nextRound();
               // ResetGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (roundNumber == 1)
            {
                playerOneRoundOne.color = new Color(1f, 0f, 0f, 1f);
                playerTwoRoundOne.color = new Color(0f, 1f, 0f, 1f);

                playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerTwo.transform.position = new Vector3(6f, -1f, 0f);

               // playerTwoWinRoundOne.SetActive(true);
               // playerOneLoseRoundOne.SetActive(true);

                gameTimer.LevelTime = 90;
                TimerText.text = Mathf.Round(gameTimer.LevelTime).ToString();

                playerTwoWins++;
                roundNumber++;
            }
            else if (roundNumber == 2)
            {
                playerOneRoundTwo.color = new Color(1f, 0f, 0f, 1f);
                playerTwoRoundTwo.color = new Color(0f, 1f, 0f, 1f);
               // playerTwoWinRoundTwo.SetActive(true);
                //playerOneLoseRoundTwo.SetActive(true);
                playerTwoWins++;
                roundNumber++;

                nextRound();
               
            }
            else if (roundNumber == 3)
            {
                playerOneRoundThree.color = new Color(1f, 0f, 0f, 1f);
                playerTwoRoundThree.color = new Color(0f, 1f, 0f, 1f);
                //playerOneWinRoundTwo.SetActive(true);
                playerTwoWins++;
                roundNumber++;

                nextRound();
               
            }

        }



        
    }
}
