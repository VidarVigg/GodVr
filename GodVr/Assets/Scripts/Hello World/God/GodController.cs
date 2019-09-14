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

    #region Test(fields + Update, etc)

    //For teleporting
    private bool ray = false;

    //For Dragging
    private bool dragging = false;
    private Vector3 grabPoint;
    private Vector3 currentPoint;

    //To enable teleporting, add TeleportOnButtonDown and Up for button down/up 

    public void Update()
    {
        //HandleInput();
        TestMethodsForUpdate();
    }

    #region Packet Core

    //private void HandleInput()
    //{
    //    //Iterate(godData.RightBitArray, godConfig.RightInputPackets);
    //    //Iterate(godData.LeftBitArray, godConfig.LeftInputPackets);
    //}
    //private void Iterate(BitArray bitArray, InputPacket[] inputPackets)
    //{

    //    if (bitArray == null)
    //    {
    //        Debug.LogError("<b>NO BITARRAY</b>");
    //        return;
    //    }

    //    if (inputPackets == null)
    //    {
    //        Debug.LogError("<b>NO INPUTPACKETS</b>");
    //        return;
    //    }

    //    for (int i = 0; i < bitArray.Length; i++)
    //    {

    //        if (bitArray[i])
    //        {

    //            for (int j = 0; j < inputPackets.Length; j++)
    //            {

    //                //if (inputPackets[j].InputID != i)
    //                //{
    //                //    continue;
    //                //}

    //                //inputPackets[j].Packet.Invoke(godMaster, godConfig, godData);
    //                break;

    //            }

    //        }

    //    }

    //}

    #endregion

    #endregion

    #region Methods

    public WorldObject Spawn(WorldObject worldObject)
    {
        return GodMaster.Instantiate(worldObject);
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

    private void PickUp(Controller123 stuff, Rigidbody rb, Controller123 other)
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

            if (other.Obj)
            {
                if (hits[nearest].transform == other.Obj.transform)
                {
                    continue;
                }
            }

            nearest = i;

        }

        if (nearest == 0)
        {

            if (other.Obj)
            {
                if (hits[nearest].transform == other.Obj.transform)
                {
                    return;
                }
            }

        }

        InteractableWorldObject obj = hits[nearest].transform.GetComponent<InteractableWorldObject>();

        if (!obj)
        {
            Debug.LogError("INTERACTABLEWORLDOBJECT PLS");
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

    #region Non-elegant solutions for movement
    //DRAG ONLY WORKS WITH 1:1 MOVEMENT, OTHERWISE IT BREAKS
    private void MovementDrag()
    {
        var pos = Vector3.zero;
        var vectorDiff = (grabPoint - currentPoint);
        godData.cameraRig.transform.position = new Vector3(pos.x, godData.cameraRig.transform.position.y, pos.z * 5.0f);
    }

    private void MovementTeleport()
    {
        godData.cameraRig.position = Ray();
    }

    private void TestMethodsForUpdate()
    {
        if (ray)
            DisplayTeleportPoint();

        if (dragging)
            MovementDrag();

        currentPoint = godData.rightControllerAttach.transform.position;
    }

    private Vector3 Ray()
    {
        Vector3 pos = godData.rightControllerAttach.position;
        RaycastHit hit;

        var nonFilthyVariable = godData.rightControllerAttach.transform.forward;
        nonFilthyVariable = Quaternion.AngleAxis(godData.aimAngleOffset, godData.rightControllerAttach.transform.right) * nonFilthyVariable;

        Physics.Raycast(pos, nonFilthyVariable, out hit);

        return hit.point;
    }

    private void DisplayTeleportPoint()
    {
        Vector3 hitPoint = Ray();

        godData.lr1.SetPosition(0, godData.rightControllerAttach.position);

        if (hitPoint != Vector3.zero)
            godData.lr1.SetPosition(1, hitPoint);

        godData.sphere.position = hitPoint;

    }

    private void DragOnButtonDown()
    {
        grabPoint = Vector3.zero;
        currentPoint = Vector3.zero;
        grabPoint = godData.rightControllerAttach.position;
        dragging = true;
    }

    private void TeleportOnButtonDown()
    {
        ray = true;
        godData.anotherTempThing.gameObject.SetActive(true);
        godData.sphere.gameObject.SetActive(true);
    }

    private void DragOnButtonUp()
    {
        grabPoint = Vector3.zero;
        currentPoint = Vector3.zero;
        dragging = false;
    }

    private void TeleportOnButtonUp()
    {
        MovementTeleport();
        ray = false;
        godData.anotherTempThing.gameObject.SetActive(false);
        godData.sphere.gameObject.SetActive(false);
    }
    #endregion

    #region Input

    public void TriggerDown(WhichID whichID)
    {

        switch (whichID)
        {

            case WhichID.Right:

                switch (godData.RightControllerStuff.State)
                {

                    case ControllerState.Empty:
                        PickUp(godData.RightControllerStuff, godData.rightControllerAttach, godData.LeftControllerStuff);
                        break;

                }

                break;

            case WhichID.Left:

                switch (godData.LeftControllerStuff.State)
                {

                    case ControllerState.Empty:
                        PickUp(godData.LeftControllerStuff, godData.leftControllerAttach, godData.RightControllerStuff);
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