using UnityEngine;
using System.Collections;

public interface ICameraSystem
{
    void Exec();
    Vector3 Forward();
    Transform GetTransform();
}