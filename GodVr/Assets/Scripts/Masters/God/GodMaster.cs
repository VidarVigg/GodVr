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

    public void GripClickDown(WhichID id)
    {
        controller.GripDown(id);
    }

    public void GripClickUp(WhichID id)
    {
        controller.GripUp(id);
    }

    public void OpenControllerMenu(WhichID id)
    {
        controller.OpenMenu(id);
    }

    public void CloseControllerMenu(WhichID id)
    {
        controller.CloseMenu(id);
    }

    public void SendTrackPadPosition(WhichID id, float horizontal, float vertical)
    {
        controller.MenuSelection(id, horizontal, vertical);
    }

    public void TrackPadClickDown(WhichID id)
    {
        controller.TrackPadClickDown(id);
    }

    public void TrackPadClickUp(WhichID id)
    {
        controller.TrackPadClickUp(id);
    }

    public void GiveObj(InteractableWorldObject obj)
    {

        if (data.RightControllerStuff.PreviousState == ControllerState.Empty)
        {
            Instantiate(obj).Grab(data.RightControllerStuff, data.rightControllerAttach);
        }
    }

    #endregion

}