using Assets.Scripts.Levels;
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
    SceneManager.LoadScene(GameState.Shared().ActualLevel.sceneName);
  }

  public void GoToNextLevel()
  {
    GameLevel actual = GameState.Shared().ActualLevel;
    List<GameLevel> levels = GameState.Shared().AvailableLevels;
    if (actual.levelIndex < levels.Count - 1)
    {
      GameLevel goToLevel = levels[actual.levelIndex + 1];
      GameState.Shared().ActualLevel = goToLevel;
      SceneManager.LoadScene(goToLevel.sceneName);
      return;
    }
    SceneManager.LoadScene(Scenes.SELECT_LEVEL);
  }
}
