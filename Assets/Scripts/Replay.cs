using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour {
    public void ReplayGame() {
        SceneManager.LoadScene(Scenes.START);
    }

    public void ReplayLevel() {
        SceneManager.LoadScene(Scenes.LEVEL);
    }
}
