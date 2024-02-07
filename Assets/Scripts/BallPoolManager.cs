using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPoolManager : MonoBehaviour
{
    [SerializeField] Ball ballPrefab;
    [SerializeField] List<Ball> pooledBalls;
    
    public static BallPoolManager Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    public Ball GetBallFromPool()
    {
        Ball ball = null;
        if(pooledBalls.Count > 0)
        {
            ball = pooledBalls[0];
            ball.gameObject.SetActive(true);
            pooledBalls.RemoveAt(0);
        }
        else
        {
            ball = Instantiate(ballPrefab.gameObject).GetComponent<Ball>();
        }
        return ball;
    }

    public void SendBallBackToPool(Ball ball)
    {
        ball.gameObject.SetActive(false);
        ball.transform.parent = transform;
        pooledBalls.Add(ball);
    }
    
}
