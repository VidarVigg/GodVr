using UnityEngine;
using System.Collections;
using Valve.VR;

public class GodController
{

    #region Fields

    private GodMaster godMaster = null;
    private GodConfig godConfig = null;
    private GodData godData = null;

    #endregion

    #region Constructors

    private GodController() { }
    public GodController(GodMaster godMaster, GodConfig godConfig, GodData godData)
    {
        this.godMaster = godMaster;
        this.godConfig = godConfig;
        this.godData = godData;
    }

    #endregion

    #region Test

    public void Update()
    {
        HandleInput();
    }

    #region Packet Core

    private void HandleInput()
    {
        //Iterate(godData.RightBitArray, godConfig.RightInputPackets);
        //Iterate(godData.LeftBitArray, godConfig.LeftInputPackets);
    }
    private void Iterate(BitArray bitArray, InputPacket[] inputPackets)
    {

        if (bitArray == null)
        {
            Debug.LogError("<b>NO BITARRAY</b>");
            return;
        }

        if (inputPackets == null)
        {
            Debug.LogError("<b>NO INPUTPACKETS</b>");
            return;
        }

        for (int i = 0; i < bitArray.Length; i++)
        {

            if (bitArray[i])
            {

                for (int j = 0; j < inputPackets.Length; j++)
                {

                    //if (inputPackets[j].InputID != i)
                    //{
                    //    continue;
                    //}

                    //inputPackets[j].Packet.Invoke(godMaster, godConfig, godData);
                    break;

                }

            }

        }

    }

    #endregion

    #region Packet Methods

    public static void HelloWorldRight()
    {
        Debug.Log("Hello World RIGHT");
    }

    public static void HelloWorldLeft()
    {
        Debug.Log("Hello World LEFT");
    }
    
    public static void TouchTrackpadDown(GodMaster godMaster, GodConfig godConfig, GodData godData)
    {

        Debug.LogWarning("HELLO");

        switch (godData.state)
        {

            //Open Menu
            case GodData.PlayerState.InMenu:

                if (!godData.heldItem)
                {
                    godData.displayItem = GodMaster.Instantiate(godData.rock);
                }

                break;

            default:
                break;

        }

    }

    #endregion

    #endregion

    #region Methods

    public WorldObject Spawn(WorldObject worldObject)
    {
        return GodMaster.Instantiate(worldObject);
    }
    private enum InputOption
    {
        TouchTrackpad_Down,
        TouchTrackpad_Up,
        Trigger_Threshhold_Down,
        Trigger_Threshhold_Up,
        Trigger_Click_Down,
        Trigger_Click_Up,
        TopMenu_Up,
        TopMenu_Down,
        RightHand,
        LeftHand
    }
    public void HandleInput(BitArray inputs)
    {
        //for (int i = 0; i < inputs.Length; i++)
        //{
        //    Debug.Log(i + " = " + inputs[i]);
        //}

        //Touch/Click Button (Personal Preference, Options Bool)
        if (inputs[(int)InputOption.TouchTrackpad_Down])
        {

            switch (godData.state)
            {

                //Open Menu
                case GodData.PlayerState.InMenu:

                    if (!godData.heldItem)
                    {
                        godData.displayItem = GodMaster.Instantiate(godData.rock);
                    }

                    break;

                default:
                    break;

            }

        }


        if (inputs[(int)InputOption.TouchTrackpad_Up])
        {

            switch (godData.state)
            {

                //Close Menu
                case GodData.PlayerState.InMenu:

                    break;

                default:
                    break;

            }

            if (godData.displayItem)
            {
                GodMaster.Destroy(godData.displayItem.gameObject);
                godData.displayItem = null;
            }

        }

        if (inputs[(int)InputOption.Trigger_Threshhold_Down])
        {

            switch (godData.state)
            {

                //Pick Up
                case GodData.PlayerState.EmptyHanded:
                    //Non Alloc Sphere Cast, Config Radius
                    //GrabObject();

                    break;

                //Grab Display Item
                case GodData.PlayerState.InMenu:

                    if (godData.displayItem)
                    {
                        //Close Menu
                        godData.heldItem = godData.displayItem;
                        godData.displayItem = null;
                    }

                    break;

                default:
                    break;

            }

        }

        if (inputs[(int)InputOption.Trigger_Threshhold_Up])
        {

            switch (godData.state)
            {

                //Place/Drop
                case GodData.PlayerState.HoldingItem:
                    //Throw/Place/Drop
                    //if (!Place())
                    //{
                    //    //Throw();
                    //}
                    break;
                case GodData.PlayerState.InMenu:
                    //Throw/Place/Drop
                    break;

                default:
                    break;

            }

        }

    }

    #endregion


    private void Throw(Controller123 stuff, SteamVR_Behaviour_Pose pose)
    {

        if (stuff.State == ControllerState.Holding)
        {
            stuff.Obj.Throw(pose);
            stuff.Obj = null;
            stuff.State = ControllerState.Empty;
        }

    }

    private int maxHits = 10;
    private int lm = 1 << 9;

    private void PickUp(Controller123 stuff, Rigidbody rb)
    {

        if (stuff.State != ControllerState.Empty)
        {
            return;
        }

        RaycastHit[] hits = new RaycastHit[maxHits];

        int count = Physics.SphereCastNonAlloc(rb.position, godData.RayCastSphereRadius, Vector3.down, hits, lm);

        if (count < 1)
        {
            return;
        }

        int nearest = 0;

        for (int i = 1; i < count; i++)
        {

            if (hits[nearest].distance < hits[i].distance)
            {
                continue;
            }

            nearest = i;

        }

        InteractableWorldObject obj = hits[nearest].transform.GetComponent<InteractableWorldObject>();

        if (!obj)
        {
            return;
        }

        obj.Grab(rb);
        stuff.Obj = obj;
        stuff.State = ControllerState.Holding;

    }

    private int maxHitsRay = 1;
    private int lmTerrain = 1 << 8;

    private bool Place(Controller123 stuff, Vector3 position)
    {

        if (stuff.State != ControllerState.Holding)
        {
            return false;
        }

        RaycastHit[] hits = new RaycastHit[maxHitsRay];

        if (Physics.RaycastNonAlloc(position, Vector3.down, hits, godData.RayPlaceDistance, lmTerrain) < 1)
        {
            return false;
        }

        stuff.Obj.Place(hits[0].point, Quaternion.Euler(hits[0].normal));
        stuff.Obj = null;
        stuff.State = ControllerState.Empty;

        return true;

    }


    private void MovementDrag()
    {

    }

    private void MovementTeleport()
    {

    }

    #region Input Whoho

    public void TriggerDown(WhichID whichID)
    {

        switch (whichID)
        {

            case WhichID.Right:

                switch (godData.RightControllerStuff.State)
                {

                    case ControllerState.Empty:
                        PickUp(godData.RightControllerStuff, godData.rightControllerAttach);
                        break;

                }

                break;

            case WhichID.Left:

                switch (godData.LeftControllerStuff.State)
                {

                    case ControllerState.Empty:
                        PickUp(godData.RightControllerStuff, godData.leftControllerAttach);
                        break;

                }

                break;

        }

    }
    public void TriggerUp(WhichID whichID)
    {

        switch (whichID)
        {

            case WhichID.Right:

                switch (godData.RightControllerStuff.State)
                {

                    case ControllerState.Holding:

                        if (!Place(godData.RightControllerStuff, godData.rightControllerAttach.position))
                        {
                            Throw(godData.RightControllerStuff, godData.rightControllerPoint);
                        }

                        break;

                }

                break;

            case WhichID.Left:

                switch (godData.LeftControllerStuff.State)
                {

                    case ControllerState.Holding:

                        if (!Place(godData.LeftControllerStuff, godData.leftControllerAttach.position))
                        {
                            Throw(godData.LeftControllerStuff, godData.leftControllerPoint);
                        }

                        break;

                }

                break;

        }

    }

    #endregion

}