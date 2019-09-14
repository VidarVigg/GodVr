﻿using System.Collections;

public interface IGodMasterService
{
    void RecieveInput(BitArray rightBitArray, BitArray leftBitArray);
    void SetInputs(BitArray rightBitArray, BitArray leftBitArray);
    void TriggerClickDown(WhichID id);
    void TriggerClickUp(WhichID id);
}
