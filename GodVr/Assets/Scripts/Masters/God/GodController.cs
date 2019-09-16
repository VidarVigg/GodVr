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

    #region Basic Actions
    private void Throw(Controller123 stuff, SteamVR_Behaviour_Pose pose)
    {

        if (stuff.State == ControllerState.Holding)
        {
            stuff.Obj.Throw(pose);
            stuff.Obj = null;
            stuff.State = ControllerState.Empty;
        }

    }
    private void PickUp(Controller123 stuff, Rigidbody rb, Controller123 other)
    {

        if (stuff.State != ControllerState.Empty)
        {
            return;
        }

        Collider[] hits = new Collider[godConfig.MaxHitsPickUpSphere];

        int count = Physics.OverlapSphereNonAlloc(rb.position, godData.RayCastSphereRadius, hits, godConfig.LayerMaskPickUp);

        if (count < 1)
        {
            return;
        }

        int nearest = 0;

        for (int i = 1; i < count; i++)
        {

            if (Vector3.Distance(rb.position, hits[nearest].transform.position) < Vector3.Distance(rb.position, hits[i].transform.position))
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
            Debug.LogWarning("INTERACTABLEWORLDOBJECT PLS");
            return;
        }

        obj.Grab(rb);
        stuff.Obj = obj;
        stuff.State = ControllerState.Holding;

    }

    private bool Place(Controller123 stuff, Vector3 position)
    {
        RaycastHit[] hits = new RaycastHit[godConfig.MaxHitRay];

        if (Physics.RaycastNonAlloc(position, Vector3.down, hits, godData.RayPlaceDistance, godConfig.LayerMaskTerrain) < 1)
        {
            Debug.Log("Failed to Place");
            return false;
        }

        stuff.Obj.Place(hits[0].point, Quaternion.Euler(hits[0].normal));
        stuff.Obj = null;
        stuff.State = ControllerState.Empty;

        return true;

    }
    #endregion

    #region Antons Old Drag (Movement)
    //private void DragOnButtonDown()
    //{
    //    grabPoint = Vector3.zero;
    //    currentPoint = Vector3.zero;
    //    grabPoint = godData.rightControllerAttach.position;
    //    dragging = true;
    //}

    //private void DragOnButtonUp()
    //{
    //    grabPoint = Vector3.zero;
    //    currentPoint = Vector3.zero;
    //    dragging = false;
    //}

    //DRAG ONLY WORKS WITH 1:1 MOVEMENT, OTHERWISE IT BREAKS
    //private void MovementDrag()
    //{
    //    var pos = Vector3.zero;
    //    var vectorDiff = (grabPoint - currentPoint);
    //    godData.cameraRig.transform.position = new Vector3(pos.x, godData.cameraRig.transform.position.y, pos.z * 5.0f);
    //}

    private Rigidbody chachedRb;

    private void TestMethodsForUpdate()
    {
        if (ray)
            DisplayTeleportPoint(chachedRb);

        //if (dragging)
        //    MovementDrag();

        currentPoint = chachedRb.transform.position;
    }
    #endregion

    #region Teleport

    public void TeleportOnButtonDown(Rigidbody rb)
    {
        ray = true;
        DisplayTeleportPoint(rb);

        currentPoint = rb.transform.position;

        //godData.anotherTempThing.gameObject.SetActive(true);
        godData.sphere.gameObject.SetActive(true);
    }

    public void TeleportOnButtonUp(Rigidbody rb)
    {

        MovementTeleport(rb);
        ray = false;
        // godData.anotherTempThing.gameObject.SetActive(false);
        godData.sphere.gameObject.SetActive(false);
    }

    private void MovementTeleport(Rigidbody rb)
    {
        godData.cameraRig.position = Ray(rb);
    }

    private void DisplayTeleportPoint(Rigidbody rb)
    {
        Vector3 hitPoint = Ray(rb);

        godData.lr1.SetPosition(0, rb.position);

        if (hitPoint != Vector3.zero)
            godData.lr1.SetPosition(1, hitPoint);

        godData.sphere.position = hitPoint;

    }

    private Vector3 Ray(Rigidbody rb)
    {
        Vector3 pos = rb.position;
        RaycastHit hit;

        Vector3 direction = rb.transform.forward;
        direction = Quaternion.AngleAxis(godData.aimAngleOffset, rb.transform.right) * direction;

        Physics.Raycast(pos, direction, out hit, 50, 1 << 8);

        return hit.point;
    }
    #endregion

    #region Input

    #region Triggers
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

    #region Grip
    public void GripDown(WhichID whichID)
    {

        switch (whichID)
        {

            case WhichID.Right:
                if (!godData.LeftControllerStuff.Planning_To_Teleport)
                {
                    TeleportOnButtonDown(godData.rightControllerAttach);
                    godData.RightControllerStuff.Planning_To_Teleport = true;
                }
                break;

            case WhichID.Left:

                if (!godData.RightControllerStuff.Planning_To_Teleport)
                {
                    TeleportOnButtonDown(godData.leftControllerAttach);
                    godData.LeftControllerStuff.Planning_To_Teleport = true;
                }
                break;

        }

    }
    public void GripUp(WhichID whichID)
    {

        switch (whichID)
        {

            case WhichID.Right:
                if (!godData.LeftControllerStuff.Planning_To_Teleport)
                {
                    if (godData.RightControllerStuff.Planning_To_Teleport)
                    {
                        godData.RightControllerStuff.Planning_To_Teleport = false;
                        TeleportOnButtonUp(godData.rightControllerAttach);
                    }
                }

                break;

            case WhichID.Left:
                if (!godData.RightControllerStuff.Planning_To_Teleport)
                {
                    if (godData.LeftControllerStuff.Planning_To_Teleport)
                    {
                        godData.LeftControllerStuff.Planning_To_Teleport = false;
                        TeleportOnButtonUp(godData.leftControllerAttach);
                    }
                }

                break;

        }

    }
    #endregion

    #endregion

}