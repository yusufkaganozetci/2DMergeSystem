using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public int ballMaxLevel = 5;
    public List<Ball> balls;
    public Ball movingBall;
    
    public static BallManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddNewBall()
    {
        Cell emptyCell = CellManager.Instance.GetRandomEmptyCell();
        if(emptyCell != null)
        {
            Ball newlyGeneratedBall = BallPoolManager.Instance.GetBallFromPool();
            newlyGeneratedBall.InitializeBall(1);
            newlyGeneratedBall.AssignToCell(emptyCell);
            emptyCell.AssignBall(newlyGeneratedBall);
            balls.Add(newlyGeneratedBall);
        }
    }

    public void GenerateBall(BallData ballData)
    {
        Ball newlyGeneratedBall = BallPoolManager.Instance.GetBallFromPool();
        Cell cell = CellManager.Instance.GetCellWithID(ballData.assignedCellID);
        newlyGeneratedBall.AssignToCell(cell);
        newlyGeneratedBall.InitializeBall(ballData.ballLevel);
        cell.AssignBall(newlyGeneratedBall);
        balls.Add(newlyGeneratedBall);
    }

    public void OnBallPicked(Ball pickedBall)
    {
        movingBall = pickedBall;
    }

    public void OnBallReleased()
    {
        movingBall = null;
    }

    public void DestroyBall(Ball ball)
    {
        balls.Remove(ball);
        BallPoolManager.Instance.SendBallBackToPool(ball);
    }

}