using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    public Image hpBar;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Health 2")
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
