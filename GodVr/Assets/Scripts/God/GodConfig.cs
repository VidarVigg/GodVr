using System;
using UnityEngine;

[Serializable]
public class GodConfig
{

    #region Fields

    [SerializeField]
    private InputPacket[] inputPackets =
    {
        new InputPacket(0, null)
    };

    #endregion

    #region Properties

    public InputPacket[] InputPackets
    {
        get { return inputPackets; }
    }

    #endregion

}
