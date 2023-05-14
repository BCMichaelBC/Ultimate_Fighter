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
    [SerializeField] CombatAI combat;
    public Combat playerOneCombat;
    public Combat playerTwoCombat;



    public float oppDistance;
    public float attackDistance = 3f;
    public bool moveAI = true;
    public bool attackState = false;


    //[SerializeField] 

    StateManager states;

    // Start is called before the first frame update
    void Start()
    {
        playerOneCombat = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Combat>();
        playerTwoCombat = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Combat>();
        states = GetComponent<StateManager>();
        // we do this to get the component rigid body form inspector so we can interact with it in code
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        if (combat == null)
            combat = GetComponent<CombatAI>();
        
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
        
        // new movement script for the AI 
        if(oppDistance > attackDistance)
        {
            if(moveAI && playerOneCombat.roundOver == false) // far from opponet and needs to walk there 
            {
                moveAI = true;
                animator.SetBool("Walking", true);
                attackState = false;
                animator.SetBool("CanAttack", false);
                if(!states.lookLeft)
                    rigid.velocity = new Vector2( walkspeed, rigid.velocity.y);
                else 
                    rigid.velocity = new Vector2(  -walkspeed, rigid.velocity.y);
            }
        }
        else
        {
            if(moveAI && playerOneCombat.roundOver == false) // far from opponent but can just stand there
            {
                moveAI = true;
                animator.SetBool("CanAttack", false);
                // combat.resetNumberAttack();
                animator.SetBool("Walking", false);
            }
        }



// stop the AI from moveing if its this close 
        if(oppDistance < attackDistance) // close to opponent 
        {
            if(moveAI)
            {
                moveAI = false;
                attackState = true;
                StartCoroutine(waitingToWalk());
            }


            if(attackState)
            {
                animator.SetBool("CanAttack", true);
                StartCoroutine(waitToAtt());
                combat.resetNumberAttack();
                StartCoroutine(AfterAttack());
            }
            else
            {
                combat.resetNumberAttack();
            }
            
        }




















        // if (jumpPressed && isGrounded)
        // {
        //     Jump();
        // }


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

    IEnumerator waitingToWalk()
    {

        
        yield return new WaitForSeconds(2f);
        moveAI = true;
       
    }

    IEnumerator waitToAtt()
    {
        
        yield return new WaitForSeconds(5f);
        combat.randomATT();

        

    }

    IEnumerator AfterAttack()
    {

        combat.resetNumberAttack();
        yield return new WaitForSeconds(3f);

    }
}
