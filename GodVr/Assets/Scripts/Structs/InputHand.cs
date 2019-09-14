using System;
using System.Collections;

[Serializable]
public class InputHand
{

    #region Fields

    private BitArray inputs;

    #endregion

    #region Properties

    public BitArray Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }

    #endregion

    #region Constructors

    private InputHand() { }
    public InputHand(int length)
    {
        inputs = new BitArray(length);
    }

    #endregion

}
