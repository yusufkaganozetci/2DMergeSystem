using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Ball : MonoBehaviour
{
    public Cell currentCell;
    public int ballLevel;
    [SerializeField] Sprite[] ballSprites;
    [SerializeField] TextMeshPro ballLevelText;
    [SerializeField] SpriteRenderer ballLevelImageSR;
    [SerializeField] SortingGroup ballLevelTextSortingGroup;
    [SerializeField] string ballSortingLayerName;
    [SerializeField] string movingBallSortingLayerName;

    private SpriteRenderer spriteRenderer;

    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        InitializeBall();
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

    public void PickTheBall()
    {
        isMoving = true;
        spriteRenderer.sortingLayerName = movingBallSortingLayerName;
        ballLevelImageSR.sortingLayerName = movingBallSortingLayerName;
        ballLevelTextSortingGroup.sortingLayerName = movingBallSortingLayerName;
        BallManager.Instance.OnBallPicked(this);
    }

    public void UpdateBall()
    {
        ballLevel++;
        InitializeBall();
    }

    public void ReleaseTheBall()
    {
        isMoving = false;
        spriteRenderer.sortingLayerName = ballSortingLayerName;
        ballLevelImageSR.sortingLayerName = ballSortingLayerName;
        ballLevelTextSortingGroup.sortingLayerName = ballSortingLayerName;

        EventManager.Instance.TriggerTheEvent(EventType.OnBallReleased, this);
    }

    private void OnMouseDown()
    {
        EventManager.Instance.TriggerTheEvent(EventType.OnBallClicked,this);
    }

    private void OnMouseUp()
    {
        ReleaseTheBall();
    }

    public void InitializeBall()
    {
        if(spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ballSprites[ballLevel - 1];
        ballLevelText.text = ballLevel.ToString();
    }
}
