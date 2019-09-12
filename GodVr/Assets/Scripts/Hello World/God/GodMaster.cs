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

    //public void ReceiveInput(BitArray rightBitArray, BitArray leftBitArray)
    //{
    //    data.RightBitArray = rightBitArray;
    //    data.LeftBitArray = leftBitArray;
    //}

    public void RecieveInput(BitArray rightBitArray, BitArray leftBitArray)
    {
        data.RightBitArray = rightBitArray;
        data.LeftBitArray = leftBitArray;
    }



    public void SetInputs(BitArray rightBitArray, BitArray leftBitArray)
    {
        //controller.SetInputs(rightBitArray, leftBitArray);
    }

    public void TriggerDown(WhichID id)
    {
        controller.TriggerDown(id);
    }

    public void TriggerUp(WhichID id)
    {
        controller.TriggerUp(id);
    }

    #endregion

}