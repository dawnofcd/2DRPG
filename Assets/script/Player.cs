using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [Header ("Move Infor")]
    [SerializeField] float xInput;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isMoving;
    

    [Header("Dash Info")]
    [SerializeField] float dashTime;
    [SerializeField] float dashDuration;  // thoi gian duoc dung chieu dash
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCoolDown; // thoi gian hoi chieu
    [SerializeField] float dashCoolDownTimer;

    

    [Header("Attack Info")]
    [SerializeField] int attackCounter = 0;
    [SerializeField] float comboTime;
    [SerializeField] float attackWindow;
    [SerializeField] bool Attacking = false;

   protected override void Start()
    {
       base.Start();
    }

    // Update is called once per frame
  protected override void Update()
    {
        base.Update();
        dashTime -= Time.deltaTime;
        dashCoolDownTimer -= Time.deltaTime;
        attackWindow -= Time.deltaTime;

        CheckInput();
        FlipController();
        Movement();
        AnimatorController();
       
    }


   
    public void CheckInput()
    {

        xInput = Input.GetAxisRaw("Horizontal");

        if (!isGrounded) // khong phai grounder thi k tan cong
            return; // khong thuc hien dong duoi nua

        if (Input.GetKey(KeyCode.Mouse0))
        {
           StartAttackEvent();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) && dashCoolDownTimer < 0)
        {
           DashAbility();
        }

    }


    public void StartAttackEvent()
    {
         if (attackWindow < 0) // tg combo 
                attackCounter = 0;
            Attacking = true;
            attackWindow = comboTime; // reset tg  combo
    }
        
    
    public void DashAbility()
    {
        dashTime = dashDuration;
        dashCoolDownTimer = dashCoolDown;
    }
    public void Movement()
    {
        if (dashTime > 0)
        {
            rb.linearVelocity = new Vector2(facingDir * dashSpeed, 0);
        }
        else
            rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);

    }
    public void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    public void AttackOver()
    {
        Attacking = false;
        attackCounter++;
        if (attackCounter > 2)
        {
            attackCounter = 0;
        }
    }
    public void AnimatorController()
    {
        isMoving = rb.linearVelocity.x != 0; // bool
        anim.SetFloat("Yvelocity", rb.linearVelocity.y);
        anim.SetBool("Ismoving", isMoving);
        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("isDashing", dashTime > 0);
        anim.SetBool("Attacking", Attacking);
        anim.SetInteger("AttackCount", attackCounter);
    }
  

    public void FlipController()
    {
        if (rb.linearVelocity.x > 0 && !facingRight)
        {
            Flip(); // char quay phải nhưng mặt char không phải bên phải thì lật cho !facingright thành bên phải
        }
        else if (rb.linearVelocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    
}

