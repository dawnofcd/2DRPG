using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] float xInput;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float sPeed  ;
    [SerializeField] float jUmpForce;

    [SerializeField] Animator anim;
    [SerializeField] bool Ismoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2  (xInput*sPeed, rb.linearVelocity.y);
        if (Input.GetKey(KeyCode.Space))
         rb.velocity= new Vector2 (rb.velocity.x, jUmpForce );

        Ismoving = rb.velocity.x !=0;

        anim.SetBool ("Ismoving", Ismoving);

    }
}
