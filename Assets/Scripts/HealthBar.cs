using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image hpBar;
    public Player player;

    //animates the Hp bar
    public void UpdateHpBar()
    {
        hpBar.fillAmount = Mathf.Clamp(player.Hp / player.maxHp, 0, 1f);
    }
}
