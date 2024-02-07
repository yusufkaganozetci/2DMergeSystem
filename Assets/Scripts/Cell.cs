using UnityEngine;

public class Cell : MonoBehaviour
{
    public int cellID;
    public Ball ball;

    public void AssignBall(Ball ball)
    {
        this.ball = ball;
    }

    public void RemoveBallFromCell()
    {
        ball = null;
    }

}