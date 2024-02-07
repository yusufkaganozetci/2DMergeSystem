using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int cellID;
    public Ball ball;//ball in the cell

    public void AssignBall(Ball ball)
    {
        this.ball = ball;
        //ball.transform.parent = transform;
    }

    public void RemoveBallFromCell()
    {
        ball = null;
    }

}