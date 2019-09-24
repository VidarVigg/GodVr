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
        rb.AddRelativeForce(Random.Range(-0.2f, 0.2f) * force,
                            1 * force,
                            Random.Range(-0.2f, 0.2f) * force);
        rb.AddTorque(Random.Range(-60, 60), Random.Range(-60, 60), Random.Range(-60, 60));
        Destroy(gameObject, lifeTime);
    }


}
