using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody2d = null;
    private static float MinInclusive = 0.0f;
    private static float MaxInclusive = 2.0f;
    private static float PositiveX = 20.0f;
    private static float NegativeX = -20.0f;
    private static float NegativeY = -15.0f;
    private static float WaitTimeBeforeExecutionInSeconds = 2.0f;
    private static float RestartimeBeforeExecutionInSeconds = 1.0f;
    private static string GoBallFunction = "GoBall";

    void GoBall()
    {
        float rand = Random.Range(MinInclusive, MaxInclusive);

        if (rigidBody2d != null)
        {
            if (rand < 1)
            {
                rigidBody2d.AddForce(new Vector2(PositiveX, NegativeY));
            }
            else
            {
                rigidBody2d.AddForce(new Vector2(NegativeX, NegativeY));
            }
        }
    }
    
    void ResetBall()
    {
        if(rigidBody2d != null)
        {
            rigidBody2d.velocity = Vector2.zero;
            transform.position = Vector2.zero;
        }
    }    

    void RestartGame()
    {
        ResetBall();
        Invoke(GoBallFunction, RestartimeBeforeExecutionInSeconds);
    }
    void OnCollisionEnter2D (Collision2D coll) 
    {
        if(rigidBody2d != null)
        {
            if(coll.collider.CompareTag("Player"))
            {
                Vector2 vel;
                vel.x = rigidBody2d.velocity.x;
                vel.y = (rigidBody2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
                rigidBody2d.velocity = vel;
            }
        }
    }
    void Start()
    {
        if(rigidBody2d != null)
        {
            rigidBody2d = GetComponent<Rigidbody2D>();
            Invoke(GoBallFunction, WaitTimeBeforeExecutionInSeconds);
        }
    }
}
