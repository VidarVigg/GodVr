using System.Collections;
using UnityEngine;

public class GodMaster : MonoBehaviour
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

    public void ReceiveInput(BitArray rightBitArray, BitArray leftBitArray)
    {
        data.RightBitArray = rightBitArray;
        data.LeftBitArray = leftBitArray;
    }

    #endregion

}