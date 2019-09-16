using UnityEngine;
public abstract class WorldObject : MonoBehaviour {

    protected virtual void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }

    protected virtual void OnCollision(Collision collision) { }

}