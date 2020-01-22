using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    public List<GameObjectState> GameObjects;

    public int Points;
    public string ActiveSceneName;

    public Save()
    {
        GameObjects = new List<GameObjectState>();
    }
}
