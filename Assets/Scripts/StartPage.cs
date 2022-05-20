using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
  public void QuitGame()
  {
    Application.Quit();
    Debug.Log("Quit");
  }

  public void StartGame()
  {
    SceneManager.LoadScene(Scenes.SELECT_LEVEL);
  }

  public void OpenOptions()
  {
    SceneManager.LoadScene(Scenes.OPTIONS);
  }
}
