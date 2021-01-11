using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRelativeToPlayer : MonoBehaviour, ICameraSystem
{
    Vector3 offset = new Vector3(0f, 1f, -5f);
    
    public Transform target;
    float lerp = .1f;

    public float sensibility = 2f;
    float mouseSensitivity = 5f;
    float factor = 6f;
    public float xRotation = 0f;

    private CameraSystem cameraSystem;

    void Awake(){
        cameraSystem = GetComponent<CameraSystem>();
        cameraSystem.AddSystem("cs1",this);
    }
    
    void Start()
    {
        // target = GameObject.Find("PlayerContainer").transform;
    }
    public void Exec()
    {
        if(!cameraSystem.canMove){
            return;
        }
        
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerp);
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0, factor);
        transform.position = new Vector3(transform.position.x, target.position.y + xRotation, transform.position.z);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;
        Vector3 tmp = target.position + target.up * (xRotation / factor );
        transform.LookAt(new Vector3(tmp.x, tmp.y + 1f, tmp.z));
    }

    public Vector3 Forward()
    {
        return new Vector3(transform.forward.x, 0, transform.forward.z);
    }
    
    public Transform GetTransform()
    {
        return transform;
    }
}