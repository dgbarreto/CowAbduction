using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    public void ReplayGame() {
        SceneManager.LoadScene(Scenes.START);
    }

    public void ReplayLevel() {
        SceneManager.LoadScene(Scenes.LEVEL);
    }
}
