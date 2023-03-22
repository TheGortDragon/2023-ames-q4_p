using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMove : MonoBehaviour {
    // Start is called before the first frame update
    public bool isGround;
    private Rigidbody2D rb2;
    public float jumpPower;
    public float speed;

    void Start() {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float x = Input.GetAxis("Horizontal");
        rb2.velocity = new Vector2(speed * x, rb2.velocity.y);
        if (Input.GetButton("Jump") && isGround) {
            rb2.AddForce(new Vector2(0, jumpPower));
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        isGround = true;
    }

    public void OnCollisionExit2D(Collision2D collision) {
        isGround = false;
    }
}
