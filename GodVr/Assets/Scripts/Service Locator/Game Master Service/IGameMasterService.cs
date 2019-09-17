using System.Collections;

public interface IGameMasterService
{

    void ReceiveInput(BitArray rightBitArray, BitArray leftBitArray);
    void ReceiveTrackPadPositions(WhichID hand, float horizontal,float vertical);


}