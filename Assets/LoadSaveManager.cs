using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
    [SerializeField] Save save;
    [SerializeField] BallManager ballManager;

    private void Start()
    {
        LoadSave();
    }
    public void LoadSave()
    {
        for(int i = 0; i < save.ballData.Count; i++)
        {
            ballManager.GenerateBall(save.ballData[i]);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        Debug.Log("Game saved!");
        save.SaveBallData(ballManager.balls);
    }
}
