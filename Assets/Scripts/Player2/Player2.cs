using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float Hp;
    public float maxHp;
    public HealthBar hpBar;

    // Update is called once per frame
    void Update()
    {
        //Press space to take damage, playtesting purposes only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage2();
        }
    }

    //Damage is either a random number or 1/4 of players current health
    //Change it to be based on attacks
    public void TakeDamage2()
    {
        Hp -= Mathf.Min(Random.value, Hp / 4f);
        hpBar.UpdateHpBar();
    }
}

