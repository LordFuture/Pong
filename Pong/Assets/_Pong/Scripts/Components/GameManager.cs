using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int PlayerScore1 = 0;
    private static int PlayerScore2 = 0;
    public GUISkin layout = null;
    private GameObject theBall = null;

    public static void Score (string wallID) 
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        } else
        {
            PlayerScore2++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI ()
    {
        if(layout != null)
        {
            GUI.skin = layout;
        }
        
        GUI.Label(new Rect(Screen.width / 2 - 200 - 72, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 200 + 24, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 125, 45, 250, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            if(theBall != null)
            {
                theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            }
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            if(theBall != null)
            {
                theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }
            
        } else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            if(theBall != null)
            {
                theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }
        }
    }    
}
