using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {


    Enemy enemyClass;
    ScoreBoard scoreBoard;

    void Start() 
    {
        enemyClass = FindObjectOfType<Enemy>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnCollisionEnter(Collision collision) 
    {
        Debug.Log("You have collided");

        switch (collision.gameObject.tag)
        {
            case "YellowBall":
                print("You hit the Yellow Ball!");
                enemyClass.YellowBallHit();
                scoreBoard.SetCountText();
                break;

            case "RedBall":
                print("You hit the Red Ball!");
                enemyClass.RedBallHit();
                scoreBoard.SetCountText();
                break;

            case "Border":
                print("You fell into the Abyss");
                scoreBoard.winText.text = "You are in the Eternal Void. restarting the game";
                //StartSameLevelSequence();
                Invoke("StartSameLevelSequence", 3f);
                break;
            default:
                HitFails();
                break;
        }
    }

    private void HitFails() {

    }

    private void StartSameLevelSequence() {
        
        SceneManager.LoadScene(1);
    }

}
