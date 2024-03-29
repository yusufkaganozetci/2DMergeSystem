using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Save")]
public class Save : ScriptableObject
{
    public List<BallData> ballData;
    
    public void SaveBallData(List<Ball> allBalls)
    {
        ballData.Clear();
        for (int i = 0; i < allBalls.Count; i++)
        {
            ballData.Add(new BallData(allBalls[i].ballLevel, allBalls[i].currentCell.cellID));
        }
    }

}