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
  public Level activeLevel;
  public Text activeTitle;
  public Image activeImage;
  public string activeScene;
  public Image prevButton;
  public Image nextButton;

  void Start()
  {
    activeTitle = GetComponentInChildren<Text>();
    activeImage = GetComponentInChildren<Image>();
    prevButton = GameObject.Find("GoToPrev").GetComponent<Image>();
    nextButton = GameObject.Find("GoToNext").GetComponent<Image>();

    if (firstLevel != null)
    {
      OnLevelSelected(firstLevel);
    }
  }


  void Update()
  {
    if (activeLevel.levelIndex > 0)
    {
      prevButton.color = new Color(prevButton.color.r, prevButton.color.g, prevButton.color.b, 1f);
    }
    else
    {
      prevButton.color = new Color(prevButton.color.r, prevButton.color.g, prevButton.color.b, 0.5f);
    }

    if (activeLevel.levelIndex < levels.Count - 1)
    {
      nextButton.color = new Color(nextButton.color.r, nextButton.color.g, nextButton.color.b, 1f);
    }
    else
    {
      nextButton.color = new Color(nextButton.color.r, nextButton.color.g, nextButton.color.b, 0.5f);
    }
  }

  public void OnLevelSelected(Level level)
  {
    activeLevel = level;
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

  public void GoToNextLevel()
  {
    if (activeLevel.levelIndex < levels.Count - 1)
    {
      OnLevelSelected(levels[activeLevel.levelIndex + 1]);
    }
  }

  public void GoToPreviousLevel()
  {
    if (activeLevel.levelIndex > 0)
    {
      OnLevelSelected(levels[activeLevel.levelIndex - 1]);
    }
  }
}
