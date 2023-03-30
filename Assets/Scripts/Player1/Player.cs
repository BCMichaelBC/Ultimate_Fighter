using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Hp;
    public float maxHp;
    public HealthBar hpBar;
    public Animator animator;

    StateManager states;
    public Winner playerUI;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StateManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckWinner()
    {
        if(playerUI.playerOneWins >= 2)
            {
                print("Player One Wins");
                playerUI.ResetGame();
            }
            else if(playerUI.playerTwoWins >= 2)
            {
                print("Player Two Wins");
                playerUI.ResetGame();
            }
            else if(playerUI.playerOneWins == 1 && playerUI.playerTwoWins == 1)
            {
                print("Round 3");
            }
    }


    public void TakeDamage()
    {
        Debug.Log("Damaged");
        animator.SetTrigger("Hit");
        states.health -= states.opponent.GetComponent<StateManager>().Ldamage;

        Hp = states.health;


        hpBar.UpdateHpBar();


        if(states.isPlayerOne)
        {

            if(Hp <= 0)
            {

                if (playerUI.roundNumber == 1)
            {
               
              
                playerUI.playerTwoWinRoundOne.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                playerUI.gameTimer.LevelTime = 90;
                playerUI.TimerText.text = Mathf.Round(playerUI.gameTimer.LevelTime).ToString();
                states.health = 100;
                Hp = 100;
                hpBar.UpdateHpBar();


                playerUI.playerTwoWins++;
                playerUI.roundNumber++;
                
            
            }
            else if (playerUI.roundNumber == 2)
            {
                   playerUI.playerTwoWinRoundTwo.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                playerUI.gameTimer.LevelTime = 90;
                playerUI.TimerText.text = Mathf.Round(playerUI.gameTimer.LevelTime).ToString();
                states.health = 100;
                Hp = 100;
                hpBar.UpdateHpBar();


                playerUI.playerTwoWins++;
                playerUI.roundNumber++;
             
            }
            else if (playerUI.roundNumber == 3)
            {

                playerUI.playerTwoWinRoundTwo.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                playerUI.gameTimer.LevelTime = 90;
                playerUI.TimerText.text = Mathf.Round(playerUI.gameTimer.LevelTime).ToString();
                states.health = 100;
                Hp = 100;
                hpBar.UpdateHpBar();


                playerUI.playerTwoWins++;
                playerUI.roundNumber++;

                print("Player Two Wins Game");

            }
            }
        }

        else if(states.isPlayerOne == false)
        {
            if(Hp <= 0)
            {
                if (playerUI.roundNumber == 1)
            {
               
               if(states.isPlayerOne == false)
               {
                   playerUI.playerOneWinRoundOne.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                playerUI.gameTimer.LevelTime = 90;
                playerUI.TimerText.text = Mathf.Round(playerUI.gameTimer.LevelTime).ToString();
                states.health = 100;
                Hp = 100;
                hpBar.UpdateHpBar();


                playerUI.playerOneWins++;
                playerUI.roundNumber++;
               }
            }
            else if (playerUI.roundNumber == 2)
            {  
               if(states.isPlayerOne == false) 
               {
                   playerUI.playerOneWinRoundTwo.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                playerUI.gameTimer.LevelTime = 90;
                playerUI.TimerText.text = Mathf.Round(playerUI.gameTimer.LevelTime).ToString();
                states.health = 100;
                Hp = 100;
                hpBar.UpdateHpBar();


                playerUI.playerOneWins++;
                playerUI.roundNumber++;
               }
            }
            else if (playerUI.roundNumber == 3)
            {
                playerUI.playerOneWinRoundTwo.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);

                playerUI.gameTimer.LevelTime = 90;
                playerUI.TimerText.text = Mathf.Round(playerUI.gameTimer.LevelTime).ToString();
                states.health = 100;
                Hp = 100;
                hpBar.UpdateHpBar();


                playerUI.playerOneWins++;
                playerUI.roundNumber++;

                print("Player One Wins Game");
               
            }
            }
        }
            CheckWinner();
    }
}
