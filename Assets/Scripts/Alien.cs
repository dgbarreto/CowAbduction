using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour {
    private const string OBSTACLE = "Obstacle";
    private const string SHIP = "Ship";
    private const string GROUND = "Ground";
    private const string WALL = "Wall";
    private const string CEILING = "Ceiling";
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform t;
    public float PullSpeed = 5.0f;
    public float Gravity = 1.0f;
    public Animator animator;
    private Renderer renderer;
    private SpriteRenderer spriteRenderer;
    public bool isColliding = false;
    //public float moveX;
    private GameObject parent;
    private AudioSource audioHit;
    private bool isInvincible = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        parent = this.transform.parent.gameObject;
        t = this.transform.parent.gameObject.GetComponent<Transform>();
        audioHit = GetComponents<AudioSource>()[1];

        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update() {
        rb.gravityScale = GameState.Shared().State == GameState.eGameState.Gaming ? - Gravity : 0;

        if ((Input.GetButton("Jump") || Input.touches.Length > 0) && GameState.Shared().State == GameState.eGameState.Gaming) {
            rb.velocity = new Vector2(0.0f, -PullSpeed);
            rb.gravityScale = -Gravity;
            sr.color = Color.white;
        }

        //if (GameState.Shared().State == GameState.eGameState.Gaming) {
        //    moveX = Input.GetAxis("Horizontal") * 3.5f * Time.deltaTime;
        //    transform.Translate(moveX, 0.0f, 0.0f);
        //}


        if (GameState.Shared().State == GameState.eGameState.Gaming) {
            animator.SetBool("isAbducting", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        isColliding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isColliding = true;

        if (collision.tag == OBSTACLE || collision.tag == WALL) {
            float moviementCoeficient = (Input.GetAxis("Horizontal") + Input.acceleration.x * 3);
            parent.transform.Translate(-moviementCoeficient * 200.0f * Time.deltaTime, 0.0f, 0.0f);

            if (!isInvincible) {
                animator.enabled = false;
                StartCoroutine(BlinkGameObject(3.0f));
                animator.enabled = true;
                audioHit.Play();
                removeOneLifePoint();
            }
        }
        else if(collision.tag == CEILING) {
            rb.velocity = new Vector2(0.0f, -PullSpeed * 2.0f);
            rb.gravityScale = -Gravity;

            if (!isInvincible) {
                animator.enabled = false;
                StartCoroutine(BlinkGameObject(3.0f));
                animator.enabled = true;
                sr.color = Color.white;
                audioHit.Play();
                removeOneLifePoint();
            }
        }
        else if (collision.tag == SHIP) {
            SceneManager.LoadScene(Scenes.WIN);
        }


        //sr.color = Color.red;

        //if(collision.tag == "WallX") {
        //    rb.velocity = new Vector2(0.0f, -5.0f);
        //}
        //else if(collision.tag == "WallY") {
        //    float moveX = Input.GetAxis("Horizontal") * -50.0f * Time.deltaTime;
        //    t.Translate(moveX, 0.0f, 0.0f);
        //    print("Collision Wall Y");
        //}
    }

    private void removeOneLifePoint() {
        GameObject lifeGauge = GameObject.Find("Life");
        if(lifeGauge != null) {
            Life lifeScript = lifeGauge.GetComponent<Life>();
            if (!lifeScript.removeOneLifePoint()) {
                Destroy(gameObject);
                SceneManager.LoadScene("Lose");
            }
        }
    }

    IEnumerator BlinkGameObject(float seconds) {
        isInvincible = true;
        DateTime dt = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now <= dt) {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }
}
