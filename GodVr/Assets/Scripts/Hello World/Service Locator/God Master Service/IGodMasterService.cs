using System.Collections;

public interface IGodMasterService
{
    void RecieveInput(BitArray rightBitArray, BitArray leftBitArray);
    void SetInputs(BitArray rightBitArray, BitArray leftBitArray);
    void TriggerDown(WhichID id);
    void TriggerUp(WhichID id);
}
