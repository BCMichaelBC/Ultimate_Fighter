using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public Timer gameTimer;

    public GameObject Player1VictoryPanel;
    public GameObject Player2VictoryPanel;
    public GameObject playerOne;
    public GameObject playerTwo;
    public TextMeshProUGUI p1name;
    public TextMeshProUGUI p2name;
    public Image p1image;
    public Image p2image;
    StateManager playerState;

    public GameObject playerOneWinRoundOne, playerOneLoseRoundOne, playerOneWinRoundTwo, playerOneLoseRoundTwo;
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
        playerState = GetComponent<StateManager>();
        p1name.text = GameManager.instance.currentCharacterPlayer1.name;
        p1image.sprite = GameManager.instance.currentCharacterPlayer1.icon;
        p2name.text = GameManager.instance.currentCharacterPlayer2.name;
        p2image.sprite = GameManager.instance.currentCharacterPlayer2.icon;
        Player1VictoryPanel.gameObject.SetActive(false);
        Player2VictoryPanel.gameObject.SetActive(false);
    }

    public void nextRound()
    {
        playerOne.transform.position = new Vector3(-6f, -1f, 0f);
        playerTwo.transform.position = new Vector3(6f, -1f, 0f);
        gameTimer.LevelTime = 90;
        TimerText.text = Mathf.Round(gameTimer.LevelTime).ToString();

        if (playerOneWins == 1)
        {
            playerOneWinRoundOne.SetActive(true);
        }
        if (playerOneWins == 2)
        {
            playerOneWinRoundTwo.SetActive(true);
        }
        if (playerTwoWins == 1)
        {
            playerTwoWinRoundOne.SetActive(true);
        }
        if (playerTwoWins == 2)
        {
            playerTwoWinRoundTwo.SetActive(true);
        }

        if (playerOneWins >= 2)
        {
            print("Player One Wins");

            ResetGame(Player1VictoryPanel);
        }
        else if (playerTwoWins >= 2)
        {
            print("Player Two Wins");
            ResetGame(Player2VictoryPanel);
        }
        else if (playerOneWins == 1 && playerTwoWins == 1)
        {
            print("Round 3");
        }
    }


    public void ResetGame(GameObject victoryPanel)
    {
        victoryPanel.SetActive(true);
        gameTimer.countdown.gameObject.SetActive(false);
        playerOne.transform.position = new Vector3(-6f, -1f, 0f);
        playerTwo.transform.position = new Vector3(6f, -1f, 0f);

        Time.timeScale = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (roundNumber == 1)
            {
                if (playerState.isPlayerOne)
                {
                    playerOneWinRoundOne.SetActive(true);

                    playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                    playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                    gameTimer.LevelTime = 90;
                    TimerText.text = Mathf.Round(gameTimer.LevelTime).ToString();

                    playerOneWins++;
                    roundNumber++;
                }
            }
            else if (roundNumber == 2)
            {
                playerOneWins++;
                roundNumber++;

                nextRound();
            }
            else if (roundNumber == 3)
            {
                playerOneWins++;
                roundNumber++;

                nextRound();
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (roundNumber == 1)
            {

                playerTwoWinRoundOne.SetActive(true);

                playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                gameTimer.LevelTime = 90;
                TimerText.text = Mathf.Round(gameTimer.LevelTime).ToString();

                playerTwoWins++;
                roundNumber++;
            }
            else if (roundNumber == 2)
            {

                playerTwoWins++;
                roundNumber++;

                nextRound();

            }
            else if (roundNumber == 3)
            {

                playerTwoWins++;
                roundNumber++;

                nextRound();
            }

        }


    }

    public void PvPRestart()
    {
        SceneManager.LoadScene("HowToPlay");
        Player1VictoryPanel.SetActive(false);
        Player2VictoryPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void PvAIRestart()
    {
        SceneManager.LoadScene("HowToPlayAI");
        Player1VictoryPanel.SetActive(false);
        Player2VictoryPanel.SetActive(false);
        Time.timeScale = 1;
    }


}
