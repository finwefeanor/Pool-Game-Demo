using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidGameController : MonoBehaviour {

    [SerializeField] GameObject cue;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject enemyBalls;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject scoreBar;
    [SerializeField] GameObject winnerMessage;

    [SerializeField] float cueMinimumX;
    [SerializeField] float cueMaximumX;
    [SerializeField] float forceOfBall;
    [SerializeField] float maxForce;
    [SerializeField] float minForce;
    [SerializeField] Vector3 strikeDirection;

    [SerializeField] const float MIN_DISTANCE = 27.5f; // strike distance between cue and cueBall
    [SerializeField] const float MAX_DISTANCE = 32f;

    //public IGameObjectState currentState;

    //public Player CurrentPlayer;
    //public Player OtherPlayer;

    private bool currentPlayerContinuesToPlay = false;
    private float force = 0f;

    float cueMovementRange;
    float cueY;
    float cueZ;
    bool IsBallOnTheCue;

    void Start() {

        cueMovementRange = cueMaximumX - cueMinimumX;
        cueY = cue.transform.position.y; // cue's starting y pos
        cueZ = cue.transform.position.z;

        IsBallOnTheCue = true;
    }

    void Update() {
        float cueX = CueMovementX();
        PlaceOfTheCue(cueX); //cueX: ball sticks with cue
        BallMovement();
    }

    private void BallMovement() {
        float cueX = CueMovementX();
        if (IsBallOnTheCue == true)
        {
            ball.transform.position = new Vector3(cueX, cueY + 0.322f, cueZ + 0.64f); // this takes ball and sticks it cue's starting Position

            if (Input.GetMouseButtonDown(0))
            {
                IsBallOnTheCue = false;

                ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forceOfBall);

            }
        }
    }

    void PlaceOfTheCue(float cuesXPosition) //Cue's Place in the Scene X Position
    {
        cue.transform.position = new Vector3(cuesXPosition, cueY, cueZ);
    }

    float CueMovementX() // takes float value rate of mouseX / Screen Width
    {
        float rate = Input.mousePosition.x / Screen.width;
        if (rate < 0)
        {
            rate = 0;
        }
        else if (rate > 1)
        {
            rate = 1;
        }

        return cueMinimumX + cueMovementRange * rate;
    }

    public void BallHitTheBorder() {
        IsBallOnTheCue = true;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    public void BallHitTheCue() // this is for arkenoid game logic, so remove if unnecessary
    {
        float difference = cue.transform.position.x - ball.transform.position.x;
        float shootingAngle = (90 * difference) + 90;

        float radyanAci = shootingAngle * ((22.0f / 7.0f) / 180.0f);
        float speedX = Mathf.Cos(radyanAci) * forceOfBall;
        float speedZ = Mathf.Sin(radyanAci) * forceOfBall;

        ball.GetComponent<Rigidbody>().velocity = new Vector3(speedX, 0, speedZ);
    }

}
