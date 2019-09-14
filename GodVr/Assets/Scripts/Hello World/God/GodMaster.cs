using System.Collections;
using UnityEngine;

public class GodMaster : MonoBehaviour, IGodMasterService
{

    #region Fields

    [SerializeField]
    private GodConfig config = null;

    [SerializeField]
    private GodData data = null;

    private GodController controller = null;

    #endregion

    #region Methods

    private void Awake()
    {
        controller = new GodController(this, config, data);
    }

    private void Update()
    {
        controller.Update();
    }

    public void TriggerClickDown(WhichID id)
    {
        controller.TriggerDown(id);
    }

    public void TriggerClickUp(WhichID id)
    {
        controller.TriggerUp(id);
    }

    #endregion

}