using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatAI : MonoBehaviour
{
    public Animator animator;
    

    public GameObject[] movementcolliders;

    StateManager states;
    [SerializeField] PlayerMovementAI attSTATE;
    [SerializeField] int numberAttack = 0;
    public bool attacking = true;
    public float atackRate = 2.0f;
    public bool roundOver;
    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StateManager>();

        attSTATE = GetComponent<PlayerMovementAI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attacking == true)
        {
            attacking = false;
            if ((Input.GetKey(KeyCode.H) && states.isPlayerOne) || (Input.GetKey(KeyCode.L) && !states.isPlayerOne)) // To block
            {
                animator.SetBool("Blocking", true);
                states.block = true;
                states.dontMove = true;
            }
            else
            {
                animator.SetBool("Blocking", false);
                states.block = false;
            }

            if ((Input.GetKey(KeyCode.S) && states.isPlayerOne) || (Input.GetKey(KeyCode.DownArrow) && !states.isPlayerOne)) // To crouch
            {
                animator.SetBool("Crouching", true);
                movementcolliders[0].SetActive(false);
                if ((Input.GetKey(KeyCode.F) && states.isPlayerOne) || (Input.GetKey(KeyCode.J) && !states.isPlayerOne)) // crouch punch
                {
                    animator.SetBool("LPunch", true);
                // Debug.Log("You crouch punched");
                    states.SelectCombatCollider(1, 10);
                }
                if ((Input.GetKey(KeyCode.G) && states.isPlayerOne) || (Input.GetKey(KeyCode.K) && !states.isPlayerOne)) // crouch kick
                {
                    animator.SetBool("LKick", true);
                    //Debug.Log("You crouch kick");
                    states.SelectCombatCollider(1, 10);
                }
            }
            else
            {
                animator.SetBool("Crouching", false);
                movementcolliders[0].SetActive(true);
            }
            if (numberAttack == 1) //  For the AI to punch
            {
                states.SelectCombatCollider(0, 10);
                animator.SetBool("HPunch", true);
                StartCoroutine(waitAfterAttack());
                //Debug.Log("You Punched");
                
            }
            if (numberAttack == 2) // kick
            {
                states.SelectCombatCollider(0, 10);
                animator.SetBool("LPunch", true);
                StartCoroutine(waitAfterAttack());
                //Debug.Log("You Kicked");
            }

            if ((Input.GetKey(KeyCode.F) && states.isPlayerOne && !states.onGround) || (Input.GetKey(KeyCode.J) && !states.isPlayerOne && !states.onGround)) // jump punch
            {
                animator.SetBool("LPunch", true);
            // Debug.Log("You jump punched");
                states.SelectCombatCollider(1, 10);
            }
            if ((Input.GetKey(KeyCode.G) && states.isPlayerOne && !states.onGround) || (Input.GetKey(KeyCode.K) && !states.isPlayerOne && !states.onGround)) // jump kick
            {
                animator.SetBool("HKick", true);
            // Debug.Log("You jump kick");
                states.SelectCombatCollider(1, 10);
            }
        }
    }

    public void resetAnimators()
    {
        //Debug.Log("Stop");
        //yield return new WaitForSeconds(1);
        animator.SetBool("LPunch", false);
        animator.SetBool("HPunch", false);
        animator.SetBool("LKick", false);
        animator.SetBool("HKick", false);

        states.CloseColliders(states.leftDamageColliders);
        states.CloseColliders(states.rightDamageColliders);
    }

    public void randomATT()
    {
       
        numberAttack = Random.Range(1,3); // number 1 - 2 just punch and kick for now mayber more later
        StartCoroutine(SetAttacking());
        
        

    }

    IEnumerator SetAttacking()
    {
        yield return new WaitForSeconds(atackRate);
        attacking = true;
    }


    IEnumerator waitAfterAttack()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("HPunch", false);
        animator.SetBool("LPunch", false);
        animator.SetBool("LKick", false);
        animator.SetBool("HKick", false);

    }
    public void resetNumberAttack()
    {
        numberAttack = 0;
    }
}