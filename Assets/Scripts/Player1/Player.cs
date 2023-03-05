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
        //Press space to take damage, playtesting purposes only
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }*/
    }

    //Damage is either a random number or 1/4 of players current health
    //Change it to be based on attacks
    public void TakeDamage()
    {
        states.health -= Mathf.Min(Random.value, Hp/4f);
        hpBar.UpdateHpBar();
    }

    public void onTriggerEnter(Collider other)
    {
        //play animation here and try to have the player take damage 
        animator.SetTrigger("Hit");
        TakeDamage();
    }
}
