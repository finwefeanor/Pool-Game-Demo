using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YellowBall : MonoBehaviour {


    [SerializeField] int scorePerHit = 12;
    [SerializeField] AudioClip hitSoundFX;
    AudioSource audioSource;

    ScoreBoard scoreBoard;

    public bool isYellowBallActive;
    RedBall redBall;

    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        redBall = FindObjectOfType<RedBall>();
        audioSource = GetComponent<AudioSource>();
        isYellowBallActive = true;
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("You have collided");

        switch (collision.gameObject.tag)
        {
            case "Border":
                print("You hit the Yellow Ball!");
                isYellowBallActive = false;
                
                break;
            default:
                break;
        }
    }

    public void YellowBallHit() {
        audioSource.PlayOneShot(hitSoundFX);
        EnemyBallScore();
    }

    void EnemyBallScore() {
        scoreBoard.ScoreHit(scorePerHit);
    }
}
