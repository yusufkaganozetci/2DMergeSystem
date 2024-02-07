using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    
    public static InputManager Instance;

    private Vector3 inputVector;
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    public Vector3 GetMousePosition()
    {
        inputVector = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        inputVector.z = 0;
        return inputVector;
    }
    
}
