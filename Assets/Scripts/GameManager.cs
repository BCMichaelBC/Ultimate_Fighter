using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character[] characters;

    public Character currentCharacterPlayer1;
    public Character currentCharacterPlayer2;
    public GameObject p1;
    public GameObject p2;
    //public GameObject p2Ryu, p2Chun, p2Ken;
    private bool isPlayer1Locked = false;
    private bool isPlayer2Locked = false;
    public CSS cssScript;
    public Timer timerScript;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        cssScript = GameObject.Find("Grid").GetComponent<CSS>();
        if(timerScript == null)
        {
            try
            {
                timerScript = GameObject.Find("Canvas").GetComponent<Timer>();
            }
            catch
            {
                return;
            }
            
        }
        

        if (characters.Length > 0)
        {
            currentCharacterPlayer1 = characters[0];
            currentCharacterPlayer2 = characters[0];
        }
        if(cssScript.p2Ryu == true)
        {
            //p2Ryu.SetActive(true);
            p2 = GameObject.FindGameObjectWithTag("Player 2");
            timerScript.p1Animator = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Animator>();
            timerScript.p2Animator = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Animator>();
        }
        if (cssScript.p2Chun == true)
        {
            //p2Chun.SetActive(true);
            p2 = GameObject.FindGameObjectWithTag("Player 2");
        }
        if (cssScript.p2Ken == true)
        {
            //p2Ken.SetActive(true);
            p2 = GameObject.FindGameObjectWithTag("Player 2");
        }
    }
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "HowToPlay")
        {
            Destroy(gameObject);
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "HowToPlayAI")
        {
            Destroy(gameObject);
        }
    }

    public void SetCharacterPlayer1(Character character)
    {
        if (!isPlayer1Locked)
        {
            currentCharacterPlayer1 = character;
            p1 = character.player1prefab;
        }
    }

    public void SetCharacterPlayer2(Character character)
    {
        if (!isPlayer2Locked)
        {
            currentCharacterPlayer2 = character;
            p2 = character.player2prefab;
        }
    }

    public void LockCharacterPlayer1()
    {
        isPlayer1Locked = true;
    }

    public void LockCharacterPlayer2()
    {
        isPlayer2Locked = true;
    }
}