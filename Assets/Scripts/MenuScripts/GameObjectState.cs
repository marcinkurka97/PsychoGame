using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameObjectState
{
    public int Id;
    public string Name;
    public float[] Position;
    public float[] Rotation;

    public GameObjectState(GameObject originalObject)
    {
        Id = originalObject.GetInstanceID();
        Name = originalObject.name;
        Position = new float[3];
        Rotation = new float[4];

        var transform = originalObject.transform;
        Position[0] = transform.position.x;
        Position[1] = transform.position.y;
        Position[2] = transform.position.z;

        var rotation = originalObject.transform.rotation;
        Rotation[0] = rotation.x;
        Rotation[1] = rotation.y;
        Rotation[2] = rotation.z;
        Rotation[3] = rotation.w;
    }
}
