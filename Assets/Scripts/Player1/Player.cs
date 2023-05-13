using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float Hp;
    public float maxHp;
    public HealthBar hpBar;
    //public Animator animator;
    public Animator animatorp1;
    public Animator animatorp2;
    
    public Timer timerScript;
    public Combat combatScriptp1;
    public Combat combatScriptp2;

    StateManager states;
    public Winner playerUI;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StateManager>();
        if (gameObject.tag == "Player 1")
        {
            states.opponent = GameObject.FindWithTag("Player 2");
            hpBar = GameObject.FindWithTag("Health 1").GetComponent<HealthBar>();
        }
        else
        {
            states.opponent = GameObject.FindWithTag("Player 1");
            hpBar = GameObject.FindWithTag("Health 2").GetComponent<HealthBar>();
        }
       // animatorp1.GameObject.FindWithTag("Player 1").GetComponent<Animator>();
       // animatorp2.GameObject.FindWithTag("Player 2").GetComponent<Animator>();
        timerScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Timer>();
        combatScriptp1 = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Combat>();
        combatScriptp2 = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enable()
    {
        hpBar.enabled = true;
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

    void ResetGame()
    {
        timerScript.Reset();
    }

    public void TakeDamage()
    {
        if(states.isPlayerOne){
        animatorp1.SetTrigger("Hit");
        }
        else if(states.isPlayerOne == false){
        animatorp2.SetTrigger("Hit");
        }
        states.health -= states.opponent.GetComponent<StateManager>().Ldamage;

        Hp = states.health;
        if(states.isPlayerOne){
        animatorp1.SetFloat("HP", Hp);
        }
        else if(states.isPlayerOne == false){
        animatorp2.SetFloat("HP", Hp);
        }
        hpBar.UpdateHpBar();


        if(states.isPlayerOne)
        {

            if(Hp <= 0)
            {
            states.dontMove = true;
            combatScriptp1.roundOver = true;
            combatScriptp2.roundOver = true;
            animatorp1.SetBool("NextRound", false);
            animatorp2.SetBool("NextRound", false);
            animatorp1.enabled = true;
            animatorp2.enabled = true;
            states.movementcolliders[1].SetActive(false);
            timerScript.Start();
            Invoke("ResetGame", 4.0f);


            if(states.isPlayerOne == false){
                states.opponent.GetComponent<Player>().animatorp1.SetTrigger("Win");
            }
            else if(states.isPlayerOne == true){
                states.opponent.GetComponent<Player>().animatorp2.SetTrigger("Win");
            }
                if (playerUI.roundNumber == 1)
            {
               
              
                playerUI.playerTwoWinRoundOne.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);
                animatorp1.enabled = true;
                animatorp2.enabled = true;
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
                animatorp1.enabled = true;
                animatorp2.enabled = true;

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
                animatorp1.enabled = true;
                animatorp2.enabled = true;
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
            states.dontMove = true;
            timerScript.Start();
            Invoke("ResetGame", 4.0f);

                combatScriptp1.roundOver = true;
                combatScriptp2.roundOver = true;
                Debug.Log("Player 1 Win");
                animatorp1.enabled = true;
                animatorp2.enabled = true;
                if(states.isPlayerOne == false){
                states.opponent.GetComponent<Player>().animatorp1.SetTrigger("Win");
                //states.opponent.GetComponent<Player>().animatorp2.SetFloat("HP", 0);
                animatorp1.SetBool("NextRound", false);
                animatorp2.SetBool("NextRound", false);
                }
                else if (states.isPlayerOne == true){
                   // states.opponent.GetComponent<Player>().animatorp1.SetFloat("HP", 0);
                    states.opponent.GetComponent<Player>().animatorp2.SetTrigger("Win");
                }
                if (playerUI.roundNumber == 1)
            {
               if(states.isPlayerOne == false)
               {
                   playerUI.playerOneWinRoundOne.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);
                animatorp1.enabled = true;
                animatorp2.enabled = true;
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
               if (states.isPlayerOne == false) 
               {
                   playerUI.playerOneWinRoundTwo.SetActive(true);

                playerUI.playerOne.transform.position = new Vector3(-6f, -1f, 0f);
                playerUI.playerTwo.transform.position = new Vector3(6f, -1f, 0f);
                animatorp1.enabled = true;
                animatorp2.enabled = true;
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
                animatorp1.enabled = true;
                animatorp2.enabled = true;
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
