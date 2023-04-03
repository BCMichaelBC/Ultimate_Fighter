using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Combat : MonoBehaviour
{
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
        if ((Input.GetKey(KeyCode.H) && states.isPlayerOne) || (Input.GetKey(KeyCode.L) && !states.isPlayerOne)) // To block
        {
            animator.SetBool("Blocking", true);
        }
        else
        {
            animator.SetBool("Blocking", false);
        }
        
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
            if ((Input.GetKeyDown(KeyCode.F) && states.isPlayerOne) || (Input.GetKeyDown(KeyCode.J) && !states.isPlayerOne)) // punch
            {
                animator.SetBool("HPunch", true);
                //Debug.Log("You Punched");
                states.SelectCombatCollider(0, 10);
            }
            if ((Input.GetKeyDown(KeyCode.G) && states.isPlayerOne) || (Input.GetKeyDown(KeyCode.K) && !states.isPlayerOne)) // kick
            {
                animator.SetBool("LPunch", true);
                // Debug.Log("You Kicked");
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
