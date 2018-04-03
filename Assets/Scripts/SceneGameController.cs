using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class SceneGameController : MonoBehaviour
{
    [SerializeField] GameObject launcher;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject mainCamera;

    //[SerializeField] float launcherMinimumX;
    //[SerializeField] float launcherMaximumX;
    [SerializeField] float maxForce;
    [SerializeField] float minForce;
    [SerializeField] Vector3 shootingDirection;

    private Vector3 cameraOffset;
    private Quaternion cameraRotation;
    private float force;

    void Start()
	{
        shootingDirection = Vector3.forward;
    }

    void LateUpdate() 
    {
        MovesCameraToTheBall();
    }

    private void MovesCameraToTheBall() 
    {
        mainCamera.transform.position = ball.transform.position - cameraOffset;
        mainCamera.transform.rotation = cameraRotation;
    }

    void FixedUpdate()
    {
        BeforeStrike();
        BeforeNextTurn();
        LateUpdate();
    }

    void BeforeNextTurn() 
    {
        cameraOffset = ball.transform.position - mainCamera.transform.position;
        cameraRotation = mainCamera.transform.rotation;
    } 

    void BeforeStrike() 
    {
        float horX = Input.GetAxis("Horizontal");

        if (horX != 0)
        {
            float angle = horX * 75 * Time.deltaTime;
            shootingDirection = Quaternion.AngleAxis(angle, Vector3.up) * shootingDirection;
            mainCamera.transform.RotateAround(ball.transform.position, Vector3.up, angle); 
        }
        Debug.DrawLine(ball.transform.position, ball.transform.position + shootingDirection * 10);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpeedOfTheBallFast();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SpeedOfTheBallSlow();
        }
    }

    private void SpeedOfTheBallSlow() {
        ball.GetComponent<Rigidbody>().AddForce(shootingDirection * minForce);
    }

    private void SpeedOfTheBallFast() 
    {
        var forceAmplitude = maxForce - minForce;
        float testforce = Mathf.PingPong(0.001f, 1.1f) * 200f; //todo shooting strenght
        Debug.Log("testforce " + testforce);
        
        //force = forceAmplitude * relativeDistance + minForce;
        ball.GetComponent<Rigidbody>().AddForce(shootingDirection * maxForce);
        Debug.Log("AddForce ");

    }

}
