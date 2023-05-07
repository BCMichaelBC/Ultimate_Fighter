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
    [SerializeField] public TextMeshProUGUI countdown;
    [SerializeField] public TextMeshProUGUI countdownDraw;
    public bool didstart = false;
    public bool newRound;
    public Player playerOne;
    public Player playerTwo;
    public Winner levelManager;
    public HealthBar playerOneHealth;
    public HealthBar playerTwoHealth;
    public StateManager playerOneState;
    public StateManager playerTwoState;
    public Animator p1Animator;
    public Animator p2Animator;
    public Combat combatScriptp1;
    public Combat combatScriptp2;

    // Start is called before the first frame update
    public void Start()
    {
        countdown.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);
        StartCoroutine(roundcountdown());

    }

    // Update is called once per frame
    void Update()

    {
        if (LevelTime > 0 && didstart == true)
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
            else if(playerTwo.Hp == playerOne.Hp && newRound == false)
            {
                newRound = true;
                //StartCoroutine("Draw", 1f);
               print("test");
               draw();
            }
         }
    }
    public void draw(){
        StartCoroutine("roundcountdown", 1f);
        print("test2");
        //newRound = true;
       // if(newRound == true){
             //       print("Draw");
               // Start();
                //StartCoroutine(roundcountdown());
                //Reset();
               // StartCoroutine("Draw", 1f);
              /*  playerOne.Hp = 100;
            playerTwo.Hp = 100;
            playerOneState.health = 100;
            playerTwoState.health = 100;
            playerOneHealth.UpdateHpBar();
            playerTwoHealth.UpdateHpBar();
            LevelTime = 3;
            TimerText.text = Mathf.Round(LevelTime).ToString();
            p1Animator.SetFloat("HP", 100);
            p2Animator.SetFloat("HP", 100);
            p1Animator.SetBool("NextRound", true);
            p2Animator.SetBool("NextRound", true);
            combatScriptp1.roundOver = true;
            combatScriptp2.roundOver = true;
            */
                playerOne.transform.position = new Vector3(-6f, -0.5f, 0f);
                 playerTwo.transform.position = new Vector3(6f, -0.5f, 0f);
                //Invoke("ResetGame", 4.0f);
              //  newRound = false;
              // }
    }

    public void Reset()
    {
        playerOne.CheckWinner();
            playerOne.Hp = 100;
            playerTwo.Hp = 100;
            playerOneState.health = 100;
            playerTwoState.health = 100;
            playerOneHealth.UpdateHpBar();
            playerTwoHealth.UpdateHpBar();
            //LevelTime = 90;
            TimerText.text = Mathf.Round(LevelTime).ToString();
            p1Animator.SetFloat("HP", 100);
            p2Animator.SetFloat("HP", 100);
            p1Animator.SetBool("NextRound", true);
            p2Animator.SetBool("NextRound", true);
            combatScriptp1.roundOver = true;
            combatScriptp2.roundOver = true;
            p1Animator.enabled = true;
            p2Animator.enabled = true;
            playerOneState.StartAnimator();
            playerTwoState.StartAnimator();
            

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
    IEnumerator Draw(){
        
        countdownDraw.gameObject.SetActive(true);
        countdown.gameObject.SetActive(false);
        countdownDraw.text = "3";
        yield return new WaitForSeconds(1);
        countdownDraw.text = "2";
        yield return new WaitForSeconds(1);
        countdownDraw.text = "1";
        yield return new WaitForSeconds(1);
        countdownDraw.text = "Round " + levelManager.roundNumber;
        yield return new WaitForSeconds(1);
        countdownDraw.text = "Fight!";
        yield return new WaitForSeconds(1);
        //countdown.gameObject.SetActive(false);
        //LevelTime = 8;
        countdownDraw.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(true);
        //playerOneState.movementcolliders[0].SetActive(true);
        //playerOneState.movementcolliders[1].SetActive(true);
        //playerTwoState.movementcolliders[0].SetActive(true);
        //playerTwoState.movementcolliders[1].SetActive(true);
        
        //combatScriptp1.roundOver = false;
        //combatScriptp2.roundOver = false;
        //playerOneState.StartAnimator();
        //playerTwoState.StartAnimator();
    }
    IEnumerator roundcountdown()
    {
        //combatScriptp1.roundOver = true;
        //combatScriptp2.roundOver = true;
        p1Animator.enabled = true;
        p2Animator.enabled = true;
        countdown.gameObject.SetActive(true);
        countdown.text = "3";
        yield return new WaitForSeconds(1);
        countdown.text = "2";
        yield return new WaitForSeconds(1);
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.text = "Round " + levelManager.roundNumber;
        yield return new WaitForSeconds(1);
        countdown.text = "Fight!";
        yield return new WaitForSeconds(1);
        countdown.gameObject.SetActive(false);
        LevelTime=90;
        TimerText.gameObject.SetActive(true);
        playerOneState.movementcolliders[0].SetActive(true);
        playerOneState.movementcolliders[1].SetActive(true);
        playerTwoState.movementcolliders[0].SetActive(true);
        playerTwoState.movementcolliders[1].SetActive(true);
        
        combatScriptp1.roundOver = false;
        combatScriptp2.roundOver = false;
        playerOneState.StartAnimator();
        playerTwoState.StartAnimator();
        //p1Animator.SetBool("NextRound", true);
       // p2Animator.SetBool("NextRound", true);
        //playerOne.transform.position = new Vector3(-6f, -1f, 0f);
        //playerTwo.transform.position = new Vector3(6f, -1f, 0f);
        didstart = true;
        newRound = false;
    }
}
