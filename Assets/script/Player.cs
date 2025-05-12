using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{  
     [Header("move info")]
     public float Speed;
     public Rigidbody2D rb;


     [Header("Collision Info")]
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask WhatIsGround;
    [SerializeField] protected bool isGrounded;
     [SerializeField] protected bool isWall;
    [SerializeField] protected Transform groundCheckPos;
    [SerializeField] protected Transform wallCheckPos;

    [SerializeField] protected float wallCheckDis;

     #region StateMachine Component
    public Animator anim {get;  private set;}
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }

    public PlayerMoveState moveState { get; private set; }

    public PlayerAirState airState {get; private set;}
    public PlayerJumpState jumpState {get ; private set;}

     #endregion
    

    void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        airState = new PlayerAirState (this, stateMachine, "Jump");
        jumpState = new PlayerJumpState (this, stateMachine, "Jump");
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
         stateMachine.Initialize(idleState);

    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity (float xvelocity, float yvelocity)
    {
        rb.linearVelocity= new Vector2 (xvelocity, yvelocity);
    }
  
   
   public bool IsGroundDetected() => Physics2D.Raycast(groundCheckPos.position, Vector2.down, groundCheckDistance, WhatIsGround);
     void OnDrawGizmos()
    {
         Gizmos.DrawLine(groundCheckPos.position, new Vector3 (groundCheckPos.position.x, groundCheckPos.position.y-groundCheckDistance));
         Gizmos.DrawLine (wallCheckPos.position, new Vector3(wallCheckPos.position.x +wallCheckDis, wallCheckPos.position.y));
    }
}
