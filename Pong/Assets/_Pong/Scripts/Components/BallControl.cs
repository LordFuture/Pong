using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody2d;
    private static float MinInclusive = 0.0f;
    private static float MaxInclusive = 2.0f;

    private static float PositiveX = 20.0f;
    private static float NegativeX = -20.0f;
    private static float NegativeY = -15.0f;
    private static float WaitTimeBeforeExecutionInSeconds = 2.0f;
    private static string GoBallFunction = "GoBall";

    void GoBall()
    {
        float rand = Random.Range(MinInclusive, MaxInclusive);

        if (rand < 1)
        {
            rigidBody2d.AddForce(new Vector2(PositiveX, NegativeY));
        }
        else
        {
            rigidBody2d.AddForce(new Vector2(NegativeX, NegativeY));
        }
    }
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        Invoke(GoBallFunction, WaitTimeBeforeExecutionInSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
