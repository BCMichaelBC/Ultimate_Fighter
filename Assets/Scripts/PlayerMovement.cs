using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] public int walkspeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        // we do this to get the component rigid body form inspector so we can interact with it in code
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the x values of movement from the player so if the player wants to move left or right
        movement = Input.GetAxis("Horizontal");
        

    }

// fixed update is for ui changes if chages were made in update they would look kinda cluncky
    void FixedUpdate()
    {
        
        rigid.velocity = new Vector2(movement * walkspeed, rigid.velocity.y);

    }
}
