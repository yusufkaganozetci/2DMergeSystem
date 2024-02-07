using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Ball : MonoBehaviour
{
    [SerializeField] Sprite[] ballSprites;
    [SerializeField] TextMeshPro ballLevelText;
    [SerializeField] SpriteRenderer ballLevelImageSR;
    [SerializeField] SortingGroup ballLevelTextSortingGroup;
    [SerializeField] string ballSortingLayerName;
    [SerializeField] string movingBallSortingLayerName;

    public Cell currentCell;
    public int ballLevel;
    
    private SpriteRenderer spriteRenderer;
    private bool isMoving = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void AssignToCell(Cell cell)
    {
        currentCell = cell;
        transform.position = cell.transform.position;
        transform.parent = cell.transform;
    }

    public void AssignPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveBall();
        }
    }

    public void MoveBall()
    {
        Vector3 desiredPos = InputManager.Instance.GetMousePosition();
        transform.position = desiredPos;
    }

    public void UpdateBall()
    {
        ballLevel++;
        InitializeBall(ballLevel);
    }

    public void PickTheBall()
    {
        isMoving = true;
        ChangeSortingLayers(movingBallSortingLayerName);
        BallManager.Instance.OnBallPicked(this);
    }

    public void ReleaseTheBall()
    {
        isMoving = false;
        ChangeSortingLayers(ballSortingLayerName);
        CellManager.Instance.SnapToCell(this);
        BallManager.Instance.OnBallReleased();
    }

    private void OnMouseDown()
    {
        PickTheBall();
    }

    private void OnMouseUp()
    {
        ReleaseTheBall();
    }

    public void InitializeBall(int ballLevel)
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        this.ballLevel = ballLevel;
        spriteRenderer.sprite = ballSprites[ballLevel - 1];
        ballLevelText.text = ballLevel.ToString();
    }

    private void ChangeSortingLayers(string layerName)
    {
        spriteRenderer.sortingLayerName = layerName;
        ballLevelImageSR.sortingLayerName = layerName;
        ballLevelTextSortingGroup.sortingLayerName = layerName;
    }

}