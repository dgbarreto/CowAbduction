using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform t;
    public float PullSpeed = 5.0f;
    public float Gravity = 1.0f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        t = this.transform.parent.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Jump")) {
            rb.velocity = new Vector2(0.0f, -PullSpeed);
            rb.gravityScale = -Gravity;
            sr.color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        sr.color = Color.red;

        if(collision.tag == "WallX") {
            rb.velocity = new Vector2(0.0f, -5.0f);
        }
        else if(collision.tag == "WallY") {
            float moveX = Input.GetAxis("Horizontal") * -50.0f * Time.deltaTime;
            t.Translate(moveX, 0.0f, 0.0f);
            print("Collision Wall Y");
        }
    }
}
