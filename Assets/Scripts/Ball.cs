using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Rigidbody rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.sleepThreshold = 0.2f;
    }

    void FixedUpdate() 
    {  
        //if (rigidBody.velocity.y > 0)
        //{
        //    var velocity = rigidBody.velocity;
        //    velocity.y *= 0.3f;
        //    rigidBody.velocity = velocity;
        //}
    }

}
