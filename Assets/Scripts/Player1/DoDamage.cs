using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{

    StateManager states;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponentInParent<StateManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) //for testing damage values
            {
                Debug.Log("Attack");
                states.opponent.GetComponent<Player>().TakeDamage();
            }
    }

    public void onTriggerEnter2D(Collider other)
    {
        //play animation here and try to have the player take damage
        Debug.Log("Triggered");
        states.opponent.GetComponent<Player>().TakeDamage();
    
    }
}
