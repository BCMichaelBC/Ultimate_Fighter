using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSS : MonoBehaviour
{
    public GameObject optionPrefab;
    public Transform prevCharacter;
    public Transform selectedCharacter;
    public Text playerIndicator;
    private bool P1isLocked = false;
    private bool P2isLocked = false;
    private int currentPlayer = 1;
    [SerializeField] private Image player1Image;
    [SerializeField] private Image player2Image;
    private void Start()
    {
        player1Image.gameObject.SetActive(false);
        player2Image.gameObject.SetActive(false);
        foreach (Character c in GameManager.instance.characters)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                if (currentPlayer == 1 && !P1isLocked)
                {
                    GameManager.instance.SetCharacterPlayer1(c);
                    player1Image.gameObject.SetActive(true);
                    player1Image.sprite = c.icon;
                    if (selectedCharacter != null)
                    {
                        prevCharacter = selectedCharacter;
                    }

                    selectedCharacter = option.transform;
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        P1isLocked = true;
                        GameManager.instance.LockCharacterPlayer1();
                        currentPlayer = 2;
                        playerIndicator.text = "Player 2, choose your character.";
                    }
                }
                else if (currentPlayer == 2 && !P2isLocked)
                {
                    GameManager.instance.SetCharacterPlayer2(c);
                    player2Image.gameObject.SetActive(true);
                    player2Image.sprite = c.icon;
                    if (selectedCharacter != null)
                    {
                        prevCharacter = selectedCharacter;
                    }
                    selectedCharacter = option.transform;
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        P2isLocked = true;
                        GameManager.instance.LockCharacterPlayer2();
                    }
                }
            });
            Text text = option.GetComponentInChildren<Text>();
            text.text = c.name;

            Image artwork = option.GetComponentInChildren<Image>();
            artwork.sprite = c.icon;
        }
    }

    private void Update()
    {
        if (selectedCharacter != null && !(P1isLocked && P2isLocked))
        {
            selectedCharacter.localScale = Vector3.Lerp(selectedCharacter.localScale, new Vector3(1.2f, 1.2f, 1.2f), Time.deltaTime * 10);
        }
        if (prevCharacter != null)
        {
            prevCharacter.localScale = Vector3.Lerp(prevCharacter.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }
    }
}

