using System.Collections;

public interface IGameMasterService
{

    void ReceiveInput(BitArray rightBitArray, BitArray leftBitArray);
    void TriggerDown(WhichID id);
    void TriggerUp(WhichID id);

}