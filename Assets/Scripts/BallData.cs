using System;

[Serializable]
public class BallData
{
    public int ballLevel, assignedCellID;

    public BallData(int ballLevel, int assignedCellID)
    {
        this.ballLevel = ballLevel;
        this.assignedCellID = assignedCellID;
    }

}