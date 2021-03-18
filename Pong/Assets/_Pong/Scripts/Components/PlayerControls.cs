using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    private static string PaddleOneOwner => "PLAYER";
    private static string PaddleTwoOwner => "OPPONENT";

    private static float InitialSpeed = 10.0f;
    private static float InitialBoundY = 2.25f;

    private KeyCode moveUp = KeyCode.W;
    private KeyCode moveDown = KeyCode.S;
    private float speed = InitialSpeed;
    private float boundY = InitialBoundY;

    private Rigidbody2D rigidBody2d = null;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();

        if(rigidBody2d != null)
        {
            string tagName = rigidBody2d.tag.ToUpper();
            if (tagName == PaddleTwoOwner)
            {
                moveUp = KeyCode.UpArrow;
                moveDown = KeyCode.DownArrow;
            }
        }
    }

    // FixedUpdate is called once per fixed time interval, Use with any component that has physics
    void FixedUpdate()
    {
        if(rigidBody2d != null)
        {
            var vel = rigidBody2d.velocity;
            if (Input.GetKey(moveUp)) 
            {
                vel.y = speed;
            }
            else if (Input.GetKey(moveDown))
            {
                vel.y = -speed;
            }
            else 
            {
                vel.y = 0;
            }

            rigidBody2d.velocity = vel;

            var pos = transform.position;
            if (pos.y > boundY) 
            {
                pos.y = boundY;
            }
            else if (pos.y < -boundY) 
            {
                pos.y = -boundY;
            }
            
            transform.position = pos;
        }
    }
}
