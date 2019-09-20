using System.Collections;

public interface IGodMasterService
{
    void TriggerClickDown(WhichID id);
    void TriggerClickUp(WhichID id);
    void GripClickDown(WhichID id);
    void GripClickUp(WhichID id);
    void OpenControllerMenu(WhichID id);
    void CloseControllerMenu(WhichID id);
    void SendTrackPadPosition(WhichID id, float horizontal, float vertical);


}
