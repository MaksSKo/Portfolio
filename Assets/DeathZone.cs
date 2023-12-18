using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public string[] ballTag;
    public BallConroller ballConroller;
    private void OnTriggerEnter2D(Collider2D col)
    {
        ballConroller.FailBall();
        if (col.CompareTag(ballTag[0]))
        {
            ballConroller.RemoveFromList(0);
            print("Got 0");

        }
        else if(col.CompareTag(ballTag[1]))
        {
            ballConroller.RemoveFromList(1);
        }
        else if(col.CompareTag(ballTag[2]))
        {
            ballConroller.RemoveFromList(2);
        }
        else if(col.CompareTag(ballTag[3]))
        {
            ballConroller.RemoveFromList(3);
        }

        Destroy(col.gameObject);

    }
}
