using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D ball = null;
    private static float MinInclusive = 0.0f;
    private static float MaxInclusive = 2.0f;
    private static float PositiveX = 20.0f;
    private static float NegativeX = -20.0f;
    private static float NegativeY = -15.0f;
    private static float WaitTimeBeforeExecutionInSeconds = 2.0f;
    private static float RestartimeBeforeExecutionInSeconds = 1.0f;
    private static string GoBallFunction = "GoBall";
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        Invoke(GoBallFunction, WaitTimeBeforeExecutionInSeconds);
    }
    void GoBall()
    {
        float rand = Random.Range(MinInclusive, MaxInclusive);
        if (rand < 1)
        {
            ball.AddForce(new Vector2(PositiveX, NegativeY));
        }
        else
        {
            ball.AddForce(new Vector2(NegativeX, NegativeY));
        }
    }

    void ResetBall()
    {
        ball.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }    

    void RestartGame()
    {
        ResetBall();
        Invoke(GoBallFunction, RestartimeBeforeExecutionInSeconds);
    }
    void OnCollisionEnter2D (Collision2D coll) 
    {
        if(coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = ball.velocity.x;
            vel.y = (ball.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            ball.velocity = vel;
        }
    }
}
