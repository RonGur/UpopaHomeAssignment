using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// a simple interface to tether a poolable object to it's pool
/// </summary>
public interface IGameObjectPooled 
{
    GameObjectPool Pool { get; set; }
}
