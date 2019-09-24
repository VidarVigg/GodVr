using UnityEngine;
using System;
using Valve.VR;
using System.Collections;

[Serializable]
public class GodData 
{

    #region Fields

    [SerializeField]
    private BitArray rightBitArray = null;

    [SerializeField]
    private BitArray leftBitArray = null;

    [Header("New")]
    [SerializeField]
    private Controller123 rightControllerStuff = null;
    [SerializeField]
    private Controller123 leftControllerStuff = null;

    [Header("Don't Touch")]
    public Rigidbody rightControllerAttach;
    public Rigidbody leftControllerAttach;
    public SteamVR_Behaviour_Pose rightControllerPoint;
    public SteamVR_Behaviour_Pose leftControllerPoint;

    [Header("Pickup Distance (Spheric)")]
    public float RayCastSphereRadius = 0.5f;

    [Header("Place Distance (Ray)")]
    public float RayPlaceDistance = 0.5f;

    #endregion

    #region Properties

    public BitArray RightBitArray
    {
        get { return rightBitArray; }
        set { rightBitArray = value; }
    }

    public BitArray LeftBitArray
    {
        get { return leftBitArray; }
        set { leftBitArray = value; }
    }

    public Controller123 RightControllerStuff
    {
        get { return rightControllerStuff; }
    }

    public Controller123 LeftControllerStuff
    {
        get { return leftControllerStuff; }
    }

    #endregion
    [Header("Menu Display")]
    [SerializeField]
    public RMF_RadialMenu rightRadialMenu;

    [SerializeField]
    public RMF_RadialMenu leftRadialMenu;


    [Header("Movment/Teleport")]
    public Transform sphere;
    public Transform cameraRig;
    public Transform anotherTempThing;
    public LineRenderer lr1;
    public float aimAngleOffset;
    [Range(10, 300)]
    public int missclickProtectionTime = 200;

    [Header("State...")]
    public PlayerState state = PlayerState.EmptyHanded;

    public enum PlayerState
    {
        EmptyHanded,
        HoldingItem,
        InMenu
    }

}
