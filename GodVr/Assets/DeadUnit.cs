using UnityEngine;

public class DeadUnit : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb = null;
    [SerializeField]
    private float force = 10f;
    [SerializeField]
    private float lifeTime = 5f;

    private void OnEnable()
    {
        rb.AddExplosionForce(force,transform.position, 1f); //TODO: needs to be changed and tweaked
        Destroy(gameObject, lifeTime);
    }


}
