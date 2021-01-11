using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementSystem : MonoBehaviour
{
    public bool canMove = true;
    public List<IDisplacementSystem> Systems = new List<IDisplacementSystem>();
    Dictionary<string, IDisplacementSystem> dictionary = new Dictionary<string, IDisplacementSystem>();
    IDisplacementSystem sysSelected;

    public void AddSystem(string str, IDisplacementSystem system){
        dictionary[str] = system;
        sysSelected = system;
    }

    public void SelectSystem(string str){
        if (dictionary.ContainsKey(str))
        { 
            sysSelected = dictionary[str];
            Debug.Log("Displacement system selected "+str);
        }  else {
            Debug.LogError("NO DISPLACEMENT SYSTEM LOADED: "+str);
        }
    }

    void Update(){
        if(sysSelected != null){
            sysSelected.Exec();
        } else {
            Debug.Log("error");
        }
    }

    public void Lock(){
        canMove = false;
    }
    public void UnLock(){
        canMove = true;
    }

    public bool CanMove(){
        return canMove;
    }
} 