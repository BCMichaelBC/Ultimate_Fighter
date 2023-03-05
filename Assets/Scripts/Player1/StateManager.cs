using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public float health = 100;
    public bool isPlayerOne = true; 

    public float vertical;
    public float horizontal;
    public bool attack1;
    public bool attack2;
    public bool attack3;
    public bool crouch;

    public bool canAttack;
    public bool gettingHit;
    public bool currentlyAttacking;

    public bool dontMove;
    public bool onGround;
    public bool lookRight;

    public GameObject[] leftDamageColliders;
    public GameObject[] rightDamageColliders;
    SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        CloseColliders(leftDamageColliders);
        CloseColliders(rightDamageColliders);
        sRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetState() //reset all states
    {
        horizontal = 0;
        vertical = 0;
        attack1 = false;
        attack2 = false;
        attack3 = false;
        gettingHit = false;
        currentlyAttacking = false;
        dontMove = false;
        isPlayerOne = true;

    }

    void FixedUpdate() // faces character to correct direction
    {
        sRenderer.flipX = lookRight;
    }

    public void SelectCombatCollider(int direction, float time) // opens/closes hitboxes as needed
    {
        if (lookRight)
        {
            OpenColliders(leftDamageColliders, direction, time);
        }
        else
        {
            OpenColliders(rightDamageColliders, direction, time);
        }
        CloseColliders(leftDamageColliders);
        CloseColliders(rightDamageColliders);
    }


    IEnumerator OpenColliders(GameObject[] collider, int index, float delay) //open specific collider
    {
        yield return new WaitForSeconds(delay);
        collider[index].SetActive(true);
    }
    void CloseColliders(GameObject[] colliders) // close specific colliders
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].SetActive(false);
        }
    }
}
