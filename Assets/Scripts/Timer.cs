using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI TimerText;
    [SerializeField] public float LevelTime = 60; //starting time 
    [SerializeField] public GameObject PausePanel;
    [SerializeField] public bool GamePaused = false;
    public TextMeshProUGUI countdown;
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
    public CombatAI combatAIScriptp2;
    public GameManager gameManagerScript;



    // Start is called before the first frame update
    public void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Player>();
        playerTwo = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Player>();
        playerOneHealth = GameObject.FindGameObjectWithTag("Health 1").GetComponent<HealthBar>();
        playerTwoHealth = GameObject.FindGameObjectWithTag("Health 2").GetComponent<HealthBar>();
        playerOneState = GameObject.FindGameObjectWithTag("Player 1").GetComponent<StateManager>();
        playerTwoState = GameObject.FindGameObjectWithTag("Player 2").GetComponent<StateManager>();
        p1Animator = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Animator>();
        p2Animator = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Animator>();
        combatScriptp1 = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Combat>();
        combatScriptp2 = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Combat>();
        combatAIScriptp2 = GameObject.FindGameObjectWithTag("Player 2").GetComponent<CombatAI>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();


        countdown.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);
        gameManagerScript.timerScript = GameObject.Find("Canvas").GetComponent<Timer>();
        //gameManagerScript.cssScript = GameObject.Find("Grid").GetComponent<CSS>();
        Debug.Log("Test 1");
        StartCoroutine(roundcountdown());
        Debug.Log("Test 2");

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

        else if (LevelTime <= 0)
        {
            if (playerOne.Hp > playerTwo.Hp)
            {
                print("Player One Wins");

                levelManager.playerOneWins++;
                if (levelManager.roundNumber == 1)
                {
                    levelManager.playerOneWinRoundOne.SetActive(true);
                }
                else if (levelManager.roundNumber >= 2)
                {
                    levelManager.playerOneWinRoundTwo.SetActive(true);
                }
                Reset();

            }
            else if (playerTwo.Hp > playerOne.Hp)
            {
                print("Player Two Wins");
                levelManager.playerTwoWins++;
                if (levelManager.roundNumber == 1)
                {
                    levelManager.playerTwoWinRoundOne.SetActive(true);
                }
                else if (levelManager.roundNumber >= 2)
                {
                    levelManager.playerTwoWinRoundTwo.SetActive(true);
                }
                Reset();
            }
            else if(playerTwo.Hp == playerOne.Hp && newRound == false)
            {
                newRound = true;
               //print("test");
               draw();
            }
        }
    }
    public void draw(){
        StartCoroutine("roundcountdown", 1f);
        //print("test2");
        playerOne.transform.position = new Vector3(-6f, -0.5f, 0f);
        playerTwo.transform.position = new Vector3(6f, -0.5f, 0f);
             
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
            TimerText.text = Mathf.Round(LevelTime).ToString();
            p1Animator.SetFloat("HP", 100);
            p2Animator.SetFloat("HP", 100);
            p1Animator.SetBool("NextRound", true);
            p2Animator.SetBool("NextRound", true);
            combatScriptp1.roundOver = true;
        if(combatScriptp2 == null)
        {
            combatAIScriptp2.roundOver = true;
        }
        else
        {
            combatScriptp2.roundOver = true;
        }
            
            p1Animator.enabled = true;
            p2Animator.enabled = true;
            playerOneState.StartAnimator();
            playerTwoState.StartAnimator();
        p1Animator.SetTrigger("NewRound");
        p2Animator.SetTrigger("NewRound");


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

    public void Menu()
    {
        SceneManager.LoadScene("StartScreen");
        PausePanel.SetActive(false);
        GamePaused = false;
        Time.timeScale = 1f;

    }

    public IEnumerator roundcountdown()
    {
        playerOneState.dontMove = true;
        playerTwoState.dontMove = true;
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
        LevelTime=60;
        TimerText.gameObject.SetActive(true);
        playerOneState.movementcolliders[0].SetActive(true);
        playerOneState.movementcolliders[1].SetActive(true);
        playerTwoState.movementcolliders[0].SetActive(true);
        playerTwoState.movementcolliders[1].SetActive(true);
        combatScriptp1.roundOver = false;
        if (combatScriptp2 == null)
        {
            combatAIScriptp2.roundOver = false;
        }
        else
        {
            combatScriptp2.roundOver = false;
        }
            
        playerOneState.StartAnimator();
        playerTwoState.StartAnimator();
        didstart = true;
        newRound = false;
        playerOneState.dontMove = false;
        playerTwoState.dontMove = false;
    }
}