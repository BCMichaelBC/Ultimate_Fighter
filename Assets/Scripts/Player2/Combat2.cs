using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat2 : MonoBehaviour
{
    public Animator animator;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            animator.SetBool("Blocking", true);
            Blocking2();
        }
        else
        {
            animator.SetBool("Blocking", false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("Crouching", true);
            Crouching2();
        }
        else
        {
            animator.SetBool("Crouching", false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("HPunching");
            HPunching2();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("LPunching");
            LPunching2();
        }
    }

    void Blocking2()
    {
        Debug.Log("You Blocked");
    }

    void Crouching2()
    {
        Debug.Log("You Crouched");
    }

    void HPunching2()
    {
        Debug.Log("You Heavy Punched");
    }

    void LPunching2()
    {
        Debug.Log("You Light Punched");
    }
}