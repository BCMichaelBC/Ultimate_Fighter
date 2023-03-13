using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAI : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    // [SerializeField] float movement;
    [SerializeField] public int walkspeed = 5;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator animator;
    [SerializeField] GameObject playerAI;


    public float oppDistance;
    public float attackDistance = 2.5f;
    public bool moveAI = true;
    public static bool attackState = false;


    //[SerializeField] 

    StateManager states;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StateManager>();
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
        // movement = Input.GetAxis("Horizontal");

        oppDistance = Vector2.Distance(states.opponent.transform.position, playerAI.transform.position);



        //Check if the player is moving, and changes the animation accordingly 
        if (Input.GetKeyDown(KeyCode.W))
            jumpPressed = true;

        faceOpponent();
    }

// fixed update is for ui changes if chages were made in update they would look kinda cluncky
    void FixedUpdate()
    {
        
        // rigid.velocity = new Vector2( walkspeed, rigid.velocity.y);

        if(oppDistance > attackDistance)
        {
            animator.SetBool("Walking", true);
            if(!states.lookLeft)
                rigid.velocity = new Vector2( walkspeed, rigid.velocity.y);
            else 
                rigid.velocity = new Vector2(  -1 * walkspeed, rigid.velocity.y);
        }
        else
        {
            animator.SetBool("Walking", false);
        }




        if (jumpPressed && isGrounded)
        {
            Jump();
        }


    }

    //for the reactions 
    public void onTriggerEnter(Collider other)
    {
        //play animation here and try to have the player take damage 
        animator.SetTrigger("Hit");
    }

    public void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        // its like (x, y) when u press to jump we arent moving horizonlty but vertically
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false; // not on ground any more 
        states.onGround = false;
        animator.SetBool("Jumping", true);
        jumpPressed = false; // to avoid double jump
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // youve hit the ground again
            states.onGround = true;
            animator.SetBool("Jumping", false);
        }
    }

    public void faceOpponent()
    {
        if (transform.position.x - states.opponent.transform.position.x < 0)
        {
            states.lookLeft = false;
        }
        else
        {
            states.lookLeft = true;
        }
    }
}
