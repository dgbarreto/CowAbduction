using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class Tab : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
  public TabGroup tabGroup;
  public Sprite tabIdle;
  public Sprite tabHover;
  public Sprite tabActive;

  public Image background;

  void Start()
  {
    background = GetComponent<Image>();
    tabGroup.Subscribe(this);
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    tabGroup.OnTabExit(this);
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    tabGroup.OnTabSelected(this);
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    tabGroup.OnTabEnter(this);
  }

  public void SetIdle()
  {
    this.background.sprite = tabIdle;
  }

  public void SetActive()
  {
    this.background.sprite = tabActive;
  }

  public void SetHover()
  {
    this.background.sprite = tabHover;
  }
}
