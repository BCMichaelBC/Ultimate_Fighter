using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combat : MonoBehaviour
{   
    public Animator animatorp1;
    public Animator animator;
    public Animator animatorp2;
    //public PlayerMovement p1Movement;
    //public PlayerMovement2 p2Movement;
    public bool roundOver;
    public float punchTimer = 5f;

    StateManager states;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        animatorp1 = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Animator>();
        animatorp2 = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Animator>();
        states = GetComponent<StateManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(roundOver == false || !states.dontMove){
            if ((Input.GetKey(KeyCode.H) && states.isPlayerOne) || (Input.GetKey(KeyCode.L) && !states.isPlayerOne)) // To block
            {
                if(states.isPlayerOne){
                animatorp1.SetBool("Blocking", true);
                }
                else if(states.isPlayerOne == false){
                animatorp2.SetBool("Blocking", true);
                }
            states.block = true;
            states.dontMove = true;
            if (states.blockedDamage)
            {
                Debug.Log(":D");
                animator.SetTrigger("NoDamage");
                states.blockedDamage = false;
            }
        }
        else
        {
            animator.SetBool("Blocking", false);
            states.block = false;
        }

            if ((Input.GetKeyUp(KeyCode.H) && states.isPlayerOne) || (Input.GetKeyUp(KeyCode.L) && !states.isPlayerOne)) // To block
                if (states.isPlayerOne)
                {
                    animatorp1.SetBool("Blocking", true);
                }
                else if (states.isPlayerOne == false)
                {
                    animatorp2.SetBool("Blocking", true);
                }
            states.block = false;
            states.dontMove = false;


            if ((Input.GetKey(KeyCode.S) && states.isPlayerOne) || (Input.GetKey(KeyCode.DownArrow) && !states.isPlayerOne)) // To crouch
        {
            animator.SetBool("Crouching", true);
            states.movementcolliders[0].SetActive(false);
            states.crouch = true;
            if ((Input.GetKeyDown(KeyCode.F) && states.isPlayerOne) || (Input.GetKeyDown(KeyCode.J) && !states.isPlayerOne)) // crouch punch
            {
                animator.SetBool("LPunch", true);
               // Debug.Log("You crouch punched");
                states.SelectCombatCollider(1, 10);
            }
            if ((Input.GetKeyDown(KeyCode.G) && states.isPlayerOne) || (Input.GetKeyDown(KeyCode.K) && !states.isPlayerOne)) // crouch kick
            {
                animator.SetBool("LKick", true);
                //Debug.Log("You crouch kick");
                states.SelectCombatCollider(1, 10);
            }
        }
        else
        {
            animator.SetBool("Crouching", false);
            states.movementcolliders[0].SetActive(true);
            states.crouch = false;
        }
        if (states.onGround && !states.crouch)
        {
            if ((Input.GetKeyDown(KeyCode.F) && states.isPlayerOne) || (Input.GetKeyDown(KeyCode.J) && !states.isPlayerOne)) // heavy punch
            {if(states.isPlayerOne){
                animatorp1.SetBool("HPunch", true);
            }else if(states.isPlayerOne == false){
                animatorp2.SetBool("HPunch", true);
            }
                punchTimer = 5f;
                roundOver = true;
                if(punchTimer > 0){
                    punchTimer -= Time.time;
                    roundOver = false;
                }
                    else if(punchTimer <= 0){
                        punchTimer = 5f;
                    }
                //animator.SetBool("HPunch", true);
                //Debug.Log("You Heavy Punched");
                states.SelectCombatCollider(0, 10);
            }
            if ((Input.GetKeyDown(KeyCode.G) && states.isPlayerOne) || (Input.GetKeyDown(KeyCode.K) && !states.isPlayerOne)) // light punch
            {
                animator.SetBool("LPunch", true);
                //Debug.Log("You Light Punched");
                states.SelectCombatCollider(0, 10);
            }
        }


        if (!states.onGround)
        {
            if ((Input.GetKeyDown(KeyCode.F) && states.isPlayerOne) || (Input.GetKeyDown(KeyCode.J) && !states.isPlayerOne)) // jump punch
            {
                animator.SetBool("LPunch", true);
                // Debug.Log("You jump punched");
                states.SelectCombatCollider(1, 10);
            }
            if ((Input.GetKeyDown(KeyCode.G) && states.isPlayerOne) || (Input.GetKeyDown(KeyCode.K) && !states.isPlayerOne)) // jump kick
            {
                animator.SetBool("HKick", true);
                // Debug.Log("You jump kick");
                states.SelectCombatCollider(1, 10);
            }
        }
        }
        else {
            return;
        }
    }

    public void resetAnimators()
    {
        animator.SetBool("LPunch", false);
        animator.SetBool("HPunch", false);
        animator.SetBool("LKick", false);
        animator.SetBool("HKick", false);

        states.CloseColliders(states.leftDamageColliders);
        states.CloseColliders(states.rightDamageColliders);
    }
}