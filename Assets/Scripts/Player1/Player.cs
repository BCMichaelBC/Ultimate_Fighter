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
        if (Input.GetKeyDown(KeyCode.M)) //for testing damage values
        {
            //TakeDamage();
        }
        
    }

    public void TakeDamage()
    {
        Debug.Log("Damaged");
        animator.SetTrigger("Hit");
        states.health -= states.opponent.GetComponent<StateManager>().Ldamage;
        Hp = states.health;
        hpBar.UpdateHpBar();
    }
}
