using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private KeyCode moveUp = KeyCode.W;
     [SerializeField]
    private KeyCode moveDown = KeyCode.S;
     [SerializeField]
    private float speed = 10.0f;
     [SerializeField]
    private float boundY = 2.25f;
     [SerializeField]
    private Rigidbody2D rigidBody2d;

    private static string PaddleOneOwner => "PLAYER";
    private static string PaddleTwoOwner => "OPPONENT";

    void Start()
    {
        Rigidbody2D rigidbody2D1 = GetComponent<Rigidbody2D>();
        rigidBody2d = rigidbody2D1;

        string tagName = rigidBody2d.tag.ToUpper();

        if(tagName == PaddleTwoOwner)
        {
            moveUp = KeyCode.UpArrow;
            moveDown = KeyCode.DownArrow;
        }
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 vel = rigidBody2d.velocity;
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

        Vector3 pos = transform.position;
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
