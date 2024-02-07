using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public void ResetGame()
    {
        List<Ball> balls = BallManager.Instance.balls;
        for (int i = 0; i < balls.Count; i++)
        {
            ResetCellAndBall(balls[i], balls[i].currentCell);
        }
        BallManager.Instance.balls.Clear();
    }

    private void OnApplicationQuit()
    {
        LoadSaveManager.Instance.SaveGame();
    }

    private void ResetCellAndBall(Ball ball, Cell cell)
    {
        cell.ball = null;
        ball.currentCell = null;
        BallPoolManager.Instance.SendBallBackToPool(ball);
    }

}