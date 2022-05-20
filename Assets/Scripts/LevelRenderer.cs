using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelRenderer : MonoBehaviour
{
  public List<Level> levels;
  public Level firstLevel;
  public Text activeTitle;
  public Image activeImage;
  public string activeScene;

  void Start()
  {
    activeTitle = GetComponentInChildren<Text>();
    activeImage = GetComponentInChildren<Image>();

    if (firstLevel != null)
    {
      OnLevelSelected(firstLevel);
    }
  }

  public void OnLevelSelected(Level level)
  {
    activeTitle.text = level.levelTitle;
    activeImage.sprite = level.levelImage;
    activeScene = level.sceneName;
  }

  void SetTitleText(string text)
  {
    activeTitle.text = text;
  }

  public void GoToLevel()
  {
    SceneManager.LoadScene(activeScene);
  }
}
