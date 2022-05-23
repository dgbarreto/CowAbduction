using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
  public void GoToStart()
  {
    SceneManager.LoadScene(Scenes.START);
  }

  public void ReplayLevel()
  {
    SceneManager.LoadScene(Scenes.LEVEL);
  }

  public void GoToNextLevel()
  {
    SceneManager.LoadScene(Scenes.LEVEL);
  }
}
