using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public void ResetGame()
    {
        List<Ball> balls = BallManager.Instance.balls;
        for (int i = 0; i < balls.Count; i++)
        {
            ResetCellAndBallInfo(balls[i], balls[i].currentCell);
        }
        BallManager.Instance.balls.Clear();
    }

    private void ResetCellAndBallInfo(Ball ball, Cell cell)
    {
        ball.ballLevel = 1;
        //ball.currentCell.ball = null;
        cell.ball = null;
        ball.currentCell = null;
        
        BallPoolManager.Instance.SendBallBackToPool(ball);
       // Destroy(ball.gameObject);
    }
}
