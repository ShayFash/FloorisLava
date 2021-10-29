using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D player;
    private Animator animator;
    [SerializeField] private float movementSpeed,jumpForce;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayers;
    private bool lookingRight;
    private int jumpCount;
    public bool LookingRight
    {
        get { return lookingRight; }
        set { 
            if(lookingRight!=value){
                rotate180();
                lookingRight = value; 
            } 
        }
    }
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lookingRight = true;
        jumpCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isGrounded",isGrounded());
        
        animator.SetBool("isRunning",Mathf.Abs(player.velocity.x)>0.1f);
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        horizontalMovement();

    }

    private void Jump()
    {
        if (isGrounded()) jumpCount = 0;
        if (jumpCount >= 2) return;
        player.velocity = new Vector2(player.velocity.x, jumpForce);
        jumpCount++;

    }

    private void rotate180()
    {
        transform.RotateAround(transform.position, transform.up, 180f);

    }
    private void horizontalMovement()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            
            int direction = (Input.GetAxis("Horizontal") > 0f) ? 1 : -1;
            
            //for changing the direction player is looking at
            bool toLookRight = (direction == 1) ? true : false;
            if (toLookRight != lookingRight)
            {
                rotate180();
                
                lookingRight = toLookRight;

            }
            
            //for moving player
            player.velocity = new Vector2(direction * movementSpeed, player.velocity.y);
            
            //for animating player to run
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);

        }
    }

    private bool isGrounded()
    {
        Collider2D touchingGround=Physics2D.OverlapCircle(feet.position, 1f,groundLayers);
        

        return touchingGround; //implicit conversion , if null return false else true
    }
}
