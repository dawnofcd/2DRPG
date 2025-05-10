using UnityEngine;

public class Enermy_Skeleton : Entity
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed;
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
    }


}
