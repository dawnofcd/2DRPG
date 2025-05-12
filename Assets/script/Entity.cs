using UnityEngine;
using UnityEngine.Rendering;

public class Entity : MonoBehaviour
{

    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator anim;

    [SerializeField] protected int facingDir = 1;
    [SerializeField] protected bool facingRight = false;

      protected bool Attacking = false;


    [Header("Collision Info")]
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask WhatIsGround;
    [SerializeField] protected bool isGrounded;
     [SerializeField] protected bool isWall;
    [SerializeField] protected Transform groundCheckPos;
    [SerializeField] protected Transform wallCheckPos;

    [SerializeField] protected float wallCheckDis;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CollisionChecks();
    }

    protected void Flip()
    {
        facingDir = facingDir * -1; // cần dòng nay để thiết lập các thông số kỹ năng khác
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    protected virtual void  CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(groundCheckPos.position, Vector2.down, groundCheckDistance, WhatIsGround);
        isWall     =Physics2D.Raycast (wallCheckPos.position, Vector2.right*facingDir, wallCheckDis, WhatIsGround);
    }
   protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPos.position, new Vector2(groundCheckPos.position.x, groundCheckPos.position.y - groundCheckDistance));
        Gizmos.DrawLine (wallCheckPos.position, new Vector2 (wallCheckPos.position.x+wallCheckDis,wallCheckPos.position.y ));
    }
}
