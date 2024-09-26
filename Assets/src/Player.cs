
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour

{
    private Rigidbody2D rb;
    private float JumpForce=5f;

    [SerializeField] float xInput;

    public int JumpTime=3 ;

    void Awake()
    {
        rb=this.gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
       
    }

        void FixedUpdate()
        {
           rb.velocity=new Vector2(xInput, rb.velocity.y);
        }
    // Update is called once per frame
    void Update()
    {
         xInput= Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && JumpTime>0 )
        {
            rb.velocity=new Vector2(0f, JumpForce);
            JumpTime--;
        }
       
    }
}
