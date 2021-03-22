using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControls : MonoBehaviour
{
    private static readonly float InitialSpeed = 10.0f;
    private static readonly float BoundY = 2.25f;
    private static readonly string PaddleOneTagName = "PLAYER";
    private static readonly string PaddleTwoTagName = "OPPONENT";

    private string axis = null;
    private Rigidbody2D paddle = null;

    void Start()
    {
        paddle = GetComponent<Rigidbody2D>();
        string paddleTag = paddle.tag;
        if(paddleTag.ToUpper() == PaddleOneTagName)
        {
            axis = "Vertical";
        }
        else if(paddleTag.ToUpper() == PaddleTwoTagName)
        {
            axis = "Vertical2";
        }
    }

    // FixedUpdate is called once per fixed time interval, Use with any component that has physics
    void FixedUpdate()
    {
        float paddleVelocity = Input.GetAxisRaw(axis);
        paddle.velocity = new Vector2(0.0f, paddleVelocity) * InitialSpeed;

        Vector3 currentPosition = transform.position;
        if(currentPosition.y > BoundY)
        {
            currentPosition.y = BoundY;
        }
        else if (currentPosition.y < -BoundY) 
        {
            currentPosition.y = -BoundY;
        }
        
        transform.position = currentPosition;
    }
}
