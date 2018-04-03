using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    //[SerializeField] GameObject deathFX;
    //[SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    int yellowBallHitScore = 1;
    int redBallHitScore = 2;
    int bigScore = 10;
    [SerializeField] AudioClip hitSoundFX;
    [SerializeField] AudioClip fellSoundFX;
    AudioSource audioSource;

    ScoreBoard scoreBoard;

    RedBall redBall;
    YellowBall yellowBall;

    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        redBall = FindObjectOfType<RedBall>();
        yellowBall = FindObjectOfType<YellowBall>();
        audioSource = GetComponent<AudioSource>();
        
    }

      void OnCollisionEnter(Collision collision) {
        Debug.Log("You have collided");

        switch (collision.gameObject.tag)
        {
                case "Border":
                print("You fell into the Abyss");
                if(yellowBall.isYellowBallActive == false && redBall.isRedBallActive == false)
                {
                    BigScore(); // todo print win message in game view
                    Invoke("LoadEndLevel", 3f);
                }
                break;
            default:
                break;
        }
    }

    private void LoadEndLevel() {
        SceneManager.LoadScene(2);
    }

    public void YellowBallHit() {
        audioSource.PlayOneShot(hitSoundFX);
        //YellowBallScore();
    }

    public void RedBallHit() {
        audioSource.PlayOneShot(hitSoundFX);
        //RedBallScore();
    }

    void HitBorder() {
        audioSource.PlayOneShot(fellSoundFX);
        BigScore();
    }

    private void BigScore() {
        scoreBoard.winText.text = "Wonderful ! You succeeded to finish! ";
    }

}
