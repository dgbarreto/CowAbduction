using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour {
    public float Speed = 2.0f;
    public Light2D light;
    private Animator openingAnimation;
    private GameObject alien;
    private Alien alienScript;
    private bool isColliding = false;

    private void Start() {
        light = GetComponentInChildren<Light2D>();
        openingAnimation = GetComponentInChildren<Animator>();
        alien = GameObject.Find("Alien");
        alienScript = alien.GetComponent<Alien>();

        GameState.Shared().State = GameState.eGameState.Opening;
    }

    void Update() {
        if (GameState.Shared().State == GameState.eGameState.Gaming && !isColliding) {
            float moveX = (Input.GetAxis("Horizontal") + Input.acceleration.x) * Speed * Time.deltaTime;
            transform.Translate(moveX, 0.0f, 0.0f);
        }

        if (openingAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
            GameState.Shared().State = GameState.eGameState.Gaming;
        }
    }

    private void OnTriggerExit2D() {
        isColliding = false;
    }

    private void OnTriggerEnter2D() {
        isColliding = true;
    }
}
