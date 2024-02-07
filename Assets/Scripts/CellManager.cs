using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] Cell[] allCells;
    [SerializeField] float thresholdDistanceForSnapping;

    public static CellManager Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    public void SnapToCell(Ball ball)
    {
        for(int i = 0; i < allCells.Length; i++)
        {
            if (Vector2.Distance(ball.transform.position, allCells[i].transform.position)
                <= thresholdDistanceForSnapping)
            {
                Ball ballInTheCell = allCells[i].ball;
                if (ballInTheCell != null && ball != ballInTheCell) 
                {
                    if(ballInTheCell.ballLevel == ball.ballLevel &&
                        ball.ballLevel != BallManager.Instance.ballMaxLevel)
                    {
                        allCells[i].RemoveBallFromCell();
                        BallManager.Instance.DestroyBall(ballInTheCell);
                        ball.UpdateBall();
                        AssignBallAndCellInfo(ball, allCells[i]);
                    }
                    else
                    {
                        ball.AssignPosition(ball.currentCell.transform.position);
                    }
                }
                else
                {
                    AssignBallAndCellInfo(ball, allCells[i]);
                }
                return;
            }
        }
        ball.AssignPosition(ball.currentCell.transform.position);
    }

    private void AssignBallAndCellInfo(Ball ball, Cell cell)
    {
        ResetCellAndBallInfo(ball, cell);
        cell.AssignBall(ball);
        ball.AssignToCell(cell);
    }

    private void ResetCellAndBallInfo(Ball ball, Cell cell)
    {
        ball.currentCell.ball = null;
        cell.ball = null;
        ball.currentCell = null;
    }

    public Cell GetCellWithID(int id)
    {
        Cell cell = null;
        for (int i = 0; i < allCells.Length; i++)
        {
            if (allCells[i].cellID == id)
            {
                cell = allCells[i];
            }
        }
        return cell;
    }

    public Cell GetRandomEmptyCell()
    {
        List<Cell> emptyCells = new List<Cell>();
        for (int i = 0; i < allCells.Length; i++)
        {
            if (allCells[i].ball == null)
            {
                emptyCells.Add(allCells[i]);
            }
        }
        return emptyCells.Count >= 1 ?
            emptyCells[Random.Range(0, emptyCells.Count)] : null;
    }

}