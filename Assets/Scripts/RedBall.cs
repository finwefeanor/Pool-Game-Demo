using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedBall : MonoBehaviour {

    [SerializeField] int scorePerHit = 12;
    [SerializeField] AudioClip hitSoundFX;
    AudioSource audioSource;

    public bool isRedBallActive;
    YellowBall yellowBall;
    ScoreBoard scoreBoard;

    void Start() {
        yellowBall = FindObjectOfType<YellowBall>();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        audioSource = GetComponent<AudioSource>();
        isRedBallActive = true;
    }

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag)
        {
            case "Border":
                print("You hit the Red Ball!");
                isRedBallActive = false;
                break;
            default:
                break;
        }
    }

    public void RedBallHit() {
        audioSource.PlayOneShot(hitSoundFX);
        EnemyBallScore();
    }

    void EnemyBallScore() {
        scoreBoard.ScoreHit(scorePerHit);
    }
}
