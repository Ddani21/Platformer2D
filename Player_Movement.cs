using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour{
    // Start is called before the first frame update
    public float movementSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpforce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    

    float mx;


    // Update is called once per frame
    private void Update(){
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }

        if (Mathf.Abs(mx) > 0.05){
            anim.SetBool("isRunning", true);
        }else{
            anim.SetBool("isRunning",false);
        }

        if (mx > 0f){ //which way is facing
            transform.localScale = new Vector3(1f,1f,1f);
        }else if (mx < 0f) {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        

        anim.SetBool("isGrounded", IsGrounded() );
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        
        rb.velocity = movement;
    }

    void Jump() {
        Vector2 movement = new Vector2(rb.velocity.x, jumpforce);

        rb.velocity = movement;
    }

    public bool IsGrounded(){
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if(groundCheck){
            return true;
        }

        return false;
    }
}
