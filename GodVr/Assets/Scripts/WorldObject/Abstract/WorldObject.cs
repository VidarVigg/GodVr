using UnityEngine;
public abstract class WorldObject : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        OnCollision();
    }

    protected virtual void OnCollision() { }

}