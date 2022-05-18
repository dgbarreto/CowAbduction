using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
    public GameObject LifeIcon;
    private List<GameObject> lambList;
    void Start() {
        lambList = new List<GameObject>();

        for (int i = 0; i < GameState.Shared().BaseLives; i++) {
            lambList.Add(addOneLifePoint());
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public GameObject addOneLifePoint() {
        var lambSpriteRenderer = LifeIcon.GetComponent<SpriteRenderer>();
        var sizeHeight = Camera.main.orthographicSize;
        var sizeWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        var lambHeight = lambSpriteRenderer.bounds.size.y;
        var lambWidth = lambSpriteRenderer.bounds.size.x;
        GameObject generatedGameObject;
        SpriteRenderer generatedSpriteRenderer;

        generatedGameObject = Instantiate(LifeIcon, new Vector3(-sizeWidth + ((lambList.Count + 1) * lambWidth), sizeHeight - lambHeight, 0.0f), Quaternion.identity);
        generatedGameObject.transform.parent = Camera.main.transform;
        generatedSpriteRenderer = generatedGameObject.GetComponent<SpriteRenderer>();
        generatedSpriteRenderer.sortingLayerName = "Foreground 2";
        return generatedGameObject;
    }

    public bool removeOneLifePoint() {
        if (lambList.Count > 0) {
            GameObject lambToRemove = lambList[lambList.Count - 1];
            lambList.RemoveAt(lambList.Count - 1);
            Destroy(lambToRemove);
            return true;
        }
        else {
            return false;
        }
    }
}
