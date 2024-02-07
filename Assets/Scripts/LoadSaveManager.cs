using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
    [SerializeField] Save save;
    [SerializeField] BallManager ballManager;

    public static LoadSaveManager Instance;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

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
        Debug.Log("Game Loaded!");
    }

    public void SaveGame()
    {
        save.SaveBallData(ballManager.balls);
        Debug.Log("Game Saved!");
    }

}