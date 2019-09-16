using System;
using UnityEngine;

[Serializable]
public class GodConfig
{

    #region Fields

    //[SerializeField]
    //private InputPacket[] rightInputPackets =
    //{
    //    new InputPacket(InputID.Trigger_Click,UpDownID.Down, ActionID.Trigger_Click_Down)
    //};

    //[SerializeField]
    //private InputPacket[] leftInputPackets =
    //{
    //    new InputPacket(InputID.Trigger_Click,UpDownID.Down, ActionID.Trigger_Click_Down)
    //};

    //#endregion

    //#region Properties

    //public InputPacket[] RightInputPackets
    //{
    //    get { return rightInputPackets; }
    //}

    //public InputPacket[] LeftInputPackets
    //{
    //    get { return leftInputPackets; }
    //}
    [Header("Placement")]
    [SerializeField]
    private int maxHitsRay = 1;
    [SerializeField]
    private LayerMask layerMaskTerrain = 1 << 8;

    [Header("Pick Up")]
    [SerializeField]
    private int maxHits = 10;

    [SerializeField]
    private LayerMask layerMaskPickUp = 1 << 9;


    public int MaxHitRay
    {
        get { return MaxHitRay; }
    }
    public LayerMask LayerMaskTerrain
    {
        get { return layerMaskTerrain; }
    }
    public int MaxHitsPickUpSphere
    {
        get { return maxHits; }
    }
    public LayerMask LayerMaskPickUp
    {
        get { return layerMaskPickUp; }
    }
    #endregion

}
