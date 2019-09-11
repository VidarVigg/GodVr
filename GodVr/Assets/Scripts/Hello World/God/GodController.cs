using UnityEngine;
using System.Collections;

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

    private void Throw(WhichID whichID)
    {
        Debug.Log("Throw In hand");
        if (godData.heldItem)
        {

            switch (whichID)
            {
                case WhichID.Right:
                    godData.heldItem.Throw(godData.rightControllerPoint);
                    break;

                case WhichID.Left:
                    godData.heldItem.Throw(godData.leftControllerPoint);
                    break;
            }


            godData.heldItem = null;
        }
        godData.state = GodData.PlayerState.EmptyHanded;
    }

    private void GrabObject(WhichID whichID)
    {
        Debug.Log("Grab Something");
        RaycastHit[] hitted = new RaycastHit[10];


        Vector3 position = Vector3.zero;

        switch (whichID)
        {

            case WhichID.Right:
                position = godData.rightControllerAttach.position;
                break;

            case WhichID.Left:
                position = godData.leftControllerAttach.position;
                break;

        }

        //Need to make it so depending on which hand that activates it.
        
        
        //Put this in Config
        int layerMask = 1 << 9;

        int numberOfHits = Physics.SphereCastNonAlloc(position, godData.RayCastSphereRadius, Vector3.down, hitted, layerMask);

        if (numberOfHits < 1)
        {
            return;
        }
        int nearestHitIndex = 0;


        for (int i = 0; i < numberOfHits; i++)
        {
            Debug.Log(hitted[i].collider.gameObject, hitted[i].collider.gameObject);
            if(hitted[nearestHitIndex].distance < hitted[i].distance)
            {
                continue;
            }
            nearestHitIndex = i;

        }
        InteractableWorldObject intObj = hitted[nearestHitIndex].transform.GetComponent<InteractableWorldObject>();
        //Debug.Log(intObj);
        if (intObj)
        {
            switch (whichID)
            {

                case WhichID.Right:
                    intObj.Grab(godData.rightControllerAttach);
                    break;

                case WhichID.Left:
                    intObj.Grab(godData.leftControllerAttach);
                    break;

            }

            godData.heldItem = intObj;
        }

        if(godData.heldItem)
        {
            godData.state = GodData.PlayerState.HoldingItem;
        }

    }

    private bool Place(WhichID whichID)
    {
        if (godData.heldItem)
        {

            Vector3 position = Vector3.zero;

            switch (whichID)
            {

                case WhichID.Right:
                    position = godData.rightControllerAttach.position;
                    break;

                case WhichID.Left:
                    position = godData.rightControllerAttach.position;
                    break;

            }

            RaycastHit hit;
            if (Physics.Raycast(position, Vector3.down, out hit, godData.RayPlaceDistance, 1 << 8))
            {
                godData.heldItem.Place(hit.point, Quaternion.identity);
                godData.heldItem = null;
                godData.state = GodData.PlayerState.EmptyHanded;
                Debug.Log("Placed Item");
                return true;
            }
        }
        return false;
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

        Debug.Log("HELLOOOOOOOOOOOOOOOOOOO");

        switch (godData.state)
        {

            //Pick Up
            case GodData.PlayerState.EmptyHanded:
                //Non Alloc Sphere Cast, Config Radius
                GrabObject(whichID);

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
    public void TriggerUp(WhichID whichID)
    {

        Debug.Log("GOOOOOOOOOOOOOOOOOODBYEEEEEEE");


        switch (godData.state)
        {

            //Place/Drop
            case GodData.PlayerState.HoldingItem:
                //Throw/Place/Drop
                if (!Place(whichID))
                {
                    Throw(whichID);
                }
                break;
            case GodData.PlayerState.InMenu:
                //Throw/Place/Drop
                break;

            default:
                break;

        }

    }

    #endregion

}