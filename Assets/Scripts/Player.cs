using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float Speed = 2.0f;

    void Update() {
        float moveX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        transform.Translate(moveX, 0.0f, 0.0f);
    }
}
