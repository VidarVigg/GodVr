using UnityEngine;
public abstract class WorldObject : MonoBehaviour
{

    private void Awake()
    {
        Setup();
    }

    protected abstract void Setup();

}