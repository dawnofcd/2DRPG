using System;
using UnityEngine;

public class Enermy_Skeleton : Entity
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed;

    [Header ("Attack Player Infor")]

   [SerializeField] float playerCheckDis ;
   [SerializeField] LayerMask whatIsPlayer;

    [SerializeField] RaycastHit2D isPlayerDetected;

   protected override void  Start()
    {
        base.Start();
    }

    // Update is called once per frame
   protected override void Update()
    {
        base.Update();
        if (!isGrounded|| isWall ) Flip();
        rb.linearVelocity = new Vector2 (moveSpeed*facingDir, rb.linearVelocityY);


   if (isPlayerDetected)
      
      {
         if (isPlayerDetected.distance >1f  ) 
        {
             Debug.Log("I was see player");
             rb.linearVelocity= new Vector2 (rb.linearVelocityX*moveSpeed*3, rb.linearVelocityY);
        }
        else 
        {
             Attacking= true ;
             Debug.Log("attack player");
        }
      } 
        
    }
   
   void Movement ()
   {
    if (!Attacking)
    {
       rb.linearVelocity= new Vector2 (rb.linearVelocityX*moveSpeed, rb.linearVelocityY);
    }
   }
   protected override void  CollisionChecks()
   {
     base.CollisionChecks();
     isPlayerDetected = Physics2D.Raycast (transform.position, Vector2.right*facingDir,playerCheckDis,whatIsPlayer);
     
   }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color= Color.blue;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x+ facingDir* playerCheckDis, transform.position.y));
    }

}
