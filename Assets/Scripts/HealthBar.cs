using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image hpBar;
    public Player player;

    public void Start()
    {
        if(gameObject.tag == "Health 1")
        {
            player = GameObject.FindWithTag("Player 1").GetComponent<Player>();
        }
        else
        {
            player = GameObject.FindWithTag("Player 2").GetComponent<Player>();
        }
    }
    //animates the Hp bar
    public void UpdateHpBar()
    {
        hpBar.fillAmount = Mathf.Clamp(player.Hp / player.maxHp, 0, 1f);
    }


}
