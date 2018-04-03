using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBallController : MonoBehaviour {

    //[SerializeField] GameObject sceneGameController;

    void Start () {
		
	}

    void OnTriggerEnter(Collider collider) {
        //sceneGameController.GetComponent<SceneGameController>().BallHitTheBorder();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Cue")
        {
            //sceneGameController.GetComponent<SceneGameController>().BallHitTheCue();
        }
    }
}
