using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    public int ballMaxLevel = 5;

    public List<Ball> balls;

    public Ball movingBall;
    
    public static BallManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.SubscribeToEvent(EventType.OnBallClicked, PickTheBall);
        EventManager.Instance.SubscribeToEvent(EventType.OnBallReleased, ReleaseTheBall);
        EventManager.Instance.SubscribeToEvent(EventType.OnBallDestroyWanted, DestroyBall);

    }

    public void AddNewBall()
    {
        Cell emptyCell = (Cell)EventManager.Instance.TriggerTheEvent(EventType.OnFreeCellWanted);
        if(emptyCell != null)
        {
            Ball newlyGeneratedBall = Instantiate(ballPrefab).GetComponent<Ball>();
            newlyGeneratedBall.AssignToCell(emptyCell);
            emptyCell.AssignBall(newlyGeneratedBall);
            balls.Add(newlyGeneratedBall);
        }
    }

    public void GenerateBall(BallData ballData)
    {
        Ball newlyGeneratedBall = Instantiate(ballPrefab).GetComponent<Ball>();
        Cell cell = CellManager.Instance.GetCellWithID(ballData.assignedCellID);
        newlyGeneratedBall.ballLevel = ballData.ballLevel;
        
        newlyGeneratedBall.AssignToCell(cell);
        newlyGeneratedBall.InitializeBall();
        cell.AssignBall(newlyGeneratedBall);
        balls.Add(newlyGeneratedBall);
    }

    

    

    public void OnBallPicked(Ball pickedBall)
    {
        movingBall = pickedBall;
    }

    public void PickTheBall(object ball)
    {
        ((Ball)ball).PickTheBall();
    }

    public Ball GetBallFromCellInfo(Cell cell)
    {
        Ball result = null;
        for(int i=0;i<balls.Count; i++)
        {
            if (balls[i].currentCell == cell)
            {
                result = balls[i];
            }
        }
        return result;
    }

    public void DestroyBall(object ball)
    {
        balls.Remove((Ball)ball);
        Destroy(((Ball)ball).gameObject);
    }

    public void ReleaseTheBall(object ball)
    {
        movingBall = null;
    }

    
}