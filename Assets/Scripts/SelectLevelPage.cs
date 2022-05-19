using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevelPage : MonoBehaviour
{
  public void GoBackToMenu()
  {
    SceneManager.LoadScene(Scenes.START);
  }
}
