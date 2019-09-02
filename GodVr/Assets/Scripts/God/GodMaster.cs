
using UnityEngine;

public class GodMaster : MonoBehaviour
{
    [SerializeField]
    private GodConfig config = null;

    [SerializeField]
    private GodData data = null;

    private GodController controller = null;

    private void Awake()
    {
        controller = new GodController(this, config, data);
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
