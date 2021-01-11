using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    Dictionary<string, ICameraSystem> dictionary = new Dictionary<string, ICameraSystem>();
    private ICameraSystem sysSelected;
    public bool canMove;

    public void AddSystem(string str, ICameraSystem system){
        dictionary[str] = system;
        sysSelected = system;
    }

    void Start(){
        if(sysSelected == null){
            Debug.Log("NO Camera System Setted");
            return;
        }
        UnLock();
        // Cursor.lockState = CursorLockMode.Locked;
        // UIManager.Start();
    }

    public void SelectSystem(string str){
        if (dictionary.ContainsKey(str))
        { 
            sysSelected = dictionary[str];
            // Debug.Log("Camera system selected "+str);
        }  else {
            Debug.LogError("NO CAMERA SYSTEM LOADED: "+str);
        }
    }

    void LateUpdate(){
        if(sysSelected != null){
            sysSelected.Exec();
        }
    }

    public void Lock(){
        canMove = false;
    }
    public void UnLock(){
        canMove = true;
    }


    public ICameraSystem  GetCurrentCamera(){
        return sysSelected;
    }
}