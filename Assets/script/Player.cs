using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] float xInput;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float sPeed  ;
    [SerializeField] float jUmpForce;

    [SerializeField] Animator anim;
    [SerializeField] bool isMoving;
    
    [SerializeField] int facingDir=1;

    [SerializeField] bool facingRight=true;
  [SerializeField] float groundCheckDistance;

  [SerializeField ] LayerMask WhatIsGround;

  [SerializeField ] bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       CheckInput();
       FlipController();
       Movement();  
       AnimatorController();
       CollisionChecks();

    }
     

     void CollisionChecks ()
     {
          isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, WhatIsGround);
     }
     public void CheckInput()
     {
        
        xInput = Input.GetAxisRaw("Horizontal");
       
        if (Input.GetKey(KeyCode.Space))
        {
           Jump();
        }
     }
     public void Movement()
     {
         rb.linearVelocity = new Vector2  (xInput*sPeed, rb.linearVelocity.y);
       
     }
    public void Jump()
    {    
        if (isGrounded)
         rb.linearVelocity= new Vector2 (rb.linearVelocity.x, jUmpForce );
    }

    public void AnimatorController()
    {
        isMoving = rb.linearVelocity.x !=0;

        anim.SetBool ("Ismoving", isMoving);
    }
    public void Flip()
    {    facingDir = facingDir *-1; // cần dòng nay để thiết lập các thông số kỹ năng khác
         facingRight = !facingRight;
         transform.Rotate(0,180, 0);
    }

    public void FlipController() 
    {
        if (rb.linearVelocity.x  > 0 && facingRight)
        {
            Flip(); // char quay phải nhưng mặt char không phải bên phải thì lật cho !facingright thành bên phải
        }
        else if (rb.linearVelocity.x < 0 && !facingRight)
        {
            Flip();
        }
    }
        
        void OnDrawGizmos()
        {
            Gizmos.DrawLine ( transform.position , new Vector2 (transform.position.x, transform.position.y - groundCheckDistance));
        }
    }

