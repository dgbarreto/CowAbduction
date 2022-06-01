using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartPage : MonoBehaviour
{
  public GameObject videoPlayer;

  void Start()
  {
    videoPlayer.transform.GetChild(0).GetComponent<VideoPlayer>().loopPointReached += CheckOver;
  }

  void CheckOver(UnityEngine.Video.VideoPlayer vp)
  {
    StartCoroutine(CloseVideo());

  }

  IEnumerator CloseVideo()
  {
    yield return new WaitForSeconds(1);
    videoPlayer.SetActive(false);
  }



  public void ShowTutorial()
  {
    videoPlayer.SetActive(true);
    VideoPlayer video = videoPlayer.transform.GetChild(0).GetComponent<VideoPlayer>();
    video.Play();
  }


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