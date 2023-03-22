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
        if (Input.GetKey(KeyCode.M)) //for testing damage values
            {
                Debug.Log("Attack");
                states.opponent.GetComponent<Player>().TakeDamage();
            }
    }


    // fixed the script by looking up the unity API on 2d colliders.  https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
    public void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log(collider.name); // testing testing
        //play animation here and try to have the player take damage
        Debug.Log("Triggered");
        states.opponent.GetComponent<Player>().TakeDamage();
    
    }
}
