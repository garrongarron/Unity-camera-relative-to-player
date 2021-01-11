using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    private Vector3 commanOrientation;
    private Vector3 cameraOrientation;
    private Vector3 forward;
    private Vector3 right;
    public static Orientation instance;
    
    
    void Start()
    {
        instance = this;
    }

    public Vector3 Move(float x, float y, Transform mainCamera, float speed){
        commanOrientation = new Vector3(x, 0f, y);
        commanOrientation = Vector3.ClampMagnitude(commanOrientation, 1);
        forward = mainCamera.forward;
        right = mainCamera.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;
        cameraOrientation = commanOrientation.x * right + commanOrientation.z * forward;
        cameraOrientation = cameraOrientation * speed;
        // Debug.Log(cameraOrientation.ToString());
        return cameraOrientation;
    }
    
}
