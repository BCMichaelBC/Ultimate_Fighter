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
    private bool isPlayer1Locked = false;
    private bool isPlayer2Locked = false;

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
        if (characters.Length > 0)
        {
            currentCharacterPlayer1 = characters[0];
            currentCharacterPlayer2 = characters[0];
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
