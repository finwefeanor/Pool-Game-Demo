using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMainMenu : MonoBehaviour {

    [SerializeField] GameObject gameElements;
    [SerializeField] GameObject canvasGameObject;

    private void Start() {

        gameElements.SetActive(true);
        canvasGameObject.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && (gameElements == true))
        {
            gameElements.SetActive(false);
            canvasGameObject.SetActive(true);
        }
    }
}
