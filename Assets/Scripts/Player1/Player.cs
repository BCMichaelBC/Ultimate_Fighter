using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Hp;
    public float maxHp;
    public HealthBar hpBar;
    public Animator animator;

    StateManager states;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StateManager>();

    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
    }

    //Damage is either a random number or 1/4 of players current health
    //Change it to be based on attacks
    public void TakeDamage()
    {
        states.health -= states.opponent.GetComponent<StateManager>().Ldamage;
        hpBar.UpdateHpBar();
    }

    public void onTriggerEnter(Collider other)
    {
        //play animation here and try to have the player take damage 
        animator.SetTrigger("Hit");
        TakeDamage();
    }
}
