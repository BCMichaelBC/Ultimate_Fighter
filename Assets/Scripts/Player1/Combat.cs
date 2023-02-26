using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("Blocking", true);
            Blocking();
        }
        else
        {
            animator.SetBool("Blocking", false);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("Crouching", true);
            Crouching();
        }
        else
        {
            animator.SetBool("Crouching", false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("HPunching");
            HPunching();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("LPunching");
            LPunching();
        }
    }

    void Blocking()
    {
        Debug.Log("You Blocked");
    }

    void Crouching()
    {
        Debug.Log("You Crouched");
    }

    void HPunching()
    {
        Debug.Log("You Heavy Punched");
    }

    void LPunching()
    {
        Debug.Log("You Light Punched");
    }
}
