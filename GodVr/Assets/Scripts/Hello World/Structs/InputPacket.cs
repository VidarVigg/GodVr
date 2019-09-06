using System;
using UnityEngine;



[Serializable]
public struct InputPacket
{

    public delegate void Packet();

    #region Fields

    [SerializeField]
    private int packetID;

    [SerializeField]
    private Packet packet;

    #endregion

    #region Constructors

    public InputPacket(int packetID, Packet packet)
    {
        this.packetID = packetID;
        this.packet = packet;
    }

    #endregion

}
