using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementRelativeToCamera : MonoBehaviour, IDisplacementSystem
{
    public CameraSystem cameraSystem;
    private Vector3 move;
    public float speed;
    public float speedBase;
    private Orientation orientation;
    public float x;
    public float y;
    private DisplacementSystem displacementSystem;
    private ICameraSystem currentCamera;
    bool flag = false;

    //
    Rigidbody rb;
    void Awake()
    {
        cameraSystem = GameObject.Find("Main Camera").GetComponent<CameraSystem>();
        orientation = GetComponent<Orientation>();
        displacementSystem = GetComponent<DisplacementSystem>();
        displacementSystem.AddSystem("ds1", this);
        Exit();
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(transform.forward );
        // rb.AddForce(transform.forward * thrust);
        
    }

    void Exit(){
        if(orientation == null){
            Debug.Log("Orientation NO LOADED");
            flag = true;
        }
        if(displacementSystem == null){
            Debug.Log("DisplacementSystem NO LOADED");
            flag = true;
        }
        // Debug.Log("CHECK DisplacementRelativeToCamera");
    }
    
    public void Exec()
    {
        if(flag){
            return;
        }
        
        if(speedBase<=0){
            Debug.Log("speedBase less than 0");
        }
        if(speed<=0){
            // Debug.Log("speed less than 0 but it take the value of speedBase");
            speed = speedBase;
        }
        move = Vector3.zero;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (displacementSystem.CanMove())
        {
            currentCamera = cameraSystem.GetCurrentCamera();
            if(currentCamera != null){
                
                move = orientation.Move(x, y, currentCamera.GetTransform().transform, speed) * Time.deltaTime;
                transform.position += move;
                // Debug.Log(transform.position);
                // rb.velocity = transform.forward * speed*speed;
                if (y+x!=0)
                {
                    currentCamera = cameraSystem.GetCurrentCamera();
                    transform.LookAt(currentCamera.Forward() + transform.position);
                }
            }
        }
    }
}