using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOptions
{

    [SerializeField]
    private WorldObject worldObject = null;

    [SerializeField]
    private Vector3 position = Vector3.zero;

    public WorldObject WorldObject
    {
        get { return worldObject; }
    }

    public Vector3 Position
    {
        get { return position; }
    }

    private AudioOptions() { }
    public AudioOptions(WorldObject worldObject)
    {
        this.worldObject = worldObject;
    }

    public AudioOptions(Vector3 position)
    {
        this.position = position;
    }

}
