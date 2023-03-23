using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMove : MonoBehaviour {
    // Start is called before the first frame update
    public bool isGround;
    private Rigidbody2D rb2;
    private SpriteRenderer sr;
    private Animator animator;
    public float jumpPower;
    public float speed;

    public Sprite CUBEEEE;

    void Start() {
        rb2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal");
        rb2.velocity = new Vector2(speed * x, rb2.velocity.y);
        if (Input.GetButton("Jump") && isGround) {
            rb2.AddForce(new Vector2(0, jumpPower));
        }
        bool moving = Mathf.Abs(x) > 0;
        if (moving) {
            sr.flipX = x < 0;
        }
        animator.SetBool("Moving", moving);

        bool crouch = Input.GetButton("Crouch");
        animator.enabled = !crouch;
        sr.sprite = CUBEEEE;

        GetComponents<BoxCollider2D>()[0].enabled = !crouch;
        GetComponents<BoxCollider2D>()[1].enabled = crouch;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        isGround = true;
    }

    public void OnCollisionExit2D(Collision2D collision) {
        isGround = false;
    }
}
