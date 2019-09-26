using UnityEngine;
using System.Diagnostics;
using System.Collections;
using Valve.VR;

public class GodController
{

    #region Fields

    private GodMaster godMaster = null;
    private GodConfig godConfig = null;
    private GodData godData = null;

    //Used for missclick protection on grip click button
    private Stopwatch stopwatch = new Stopwatch();

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
            ServiceLocator.TestAudioMasterService.PlayOneShot(AudioType.SFXThrow, pose.GetComponent<AudioSource>());
            stuff.Obj.Throw(pose);
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
            UnityEngine.Debug.LogWarning("INTERACTABLEWORLDOBJECT PLS");
            return;
        }

        obj.Grab(stuff,rb);
        

    }

    private bool Place(Controller123 stuff, Vector3 position)
    {
        RaycastHit[] hits = new RaycastHit[godConfig.MaxHitRay];

        if (Physics.RaycastNonAlloc(position, Vector3.down, hits, godData.RayPlaceDistance, godConfig.LayerMaskTerrain) < 1)
        {
            UnityEngine.Debug.Log("Failed to Place");
            return false;
        }

        //Keep hand rotation
        var rotation = stuff.Obj.transform.eulerAngles = (new Vector3(0.0f, stuff.Obj.transform.eulerAngles.y, 0.0f));

        return stuff.Obj.Place(hits[0].point, Quaternion.Euler(rotation));
    }

   public void ClearHand(InteractableWorldObject obj)
    {
        if (godData.LeftControllerStuff.Obj == obj)
        {
            godData.RightControllerStuff.Obj = null;
            godData.LeftControllerStuff.State = ControllerState.Empty;
        }

        if (godData.RightControllerStuff.Obj == obj)
        {
            godData.RightControllerStuff.Obj = null;
            godData.LeftControllerStuff.State = ControllerState.Empty;
        }
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
        if(chachedRb)
            currentPoint = chachedRb.transform.position;
    }
    #endregion

    #region Teleport

    public void TeleportOnButtonDown(Rigidbody rb)
    {
        stopwatch.Reset();
        stopwatch.Start();
        ray = true;
        DisplayTeleportPoint(rb);

        currentPoint = rb.transform.position;
        chachedRb = rb;
        godData.sphere.gameObject.SetActive(true);
    }

    public void TeleportOnButtonUp(Rigidbody rb)
    {
        stopwatch.Stop();
        var time = stopwatch.ElapsedMilliseconds;
        //UnityEngine.Debug.Log("grip button held for " + time + " ms");
        if (time >= godData.missclickProtectionTime)
        {
            MovementTeleport(rb);
        }
        ray = false;
        godData.sphere.gameObject.SetActive(false);
    }

    private void MovementTeleport(Rigidbody rb)
    {
        Vector3 positionOfCameraOnTeleportArea = TransfromsPositionOnTeleport(godData.cameraTransform);

        Vector3 offset = positionOfCameraOnTeleportArea == Vector3.zero ? Vector3.zero : positionOfCameraOnTeleportArea - (new Vector3(godData.cameraRig.transform.position.x, 0, godData.cameraRig.transform.position.z));
        godData.cameraRig.position = Ray(rb) + (Vector3.down * godData.yPositionOffset) - offset; 
    }

    private void DisplayTeleportPoint(Rigidbody rb) //gomenasorry /anton
    {
        Vector3 hitPoint = Ray(rb);

        godData.lr1.SetPosition(0, rb.position);


        if (hitPoint != godMaster.transform.position)
        {
            godData.lr1.colorGradient = godData.allowedTeleportColor;
            godData.lr1.SetPositions(CalculateLineRenderPoints(rb.position, hitPoint));
        }
        else
        {
            godData.lr1.colorGradient = godData.disallowedTeleportColor;

            Vector3 direction = rb.transform.forward;
            direction = Quaternion.AngleAxis(godData.aimAngleOffset, rb.transform.right) * direction;

            UnityEngine.Debug.DrawLine(rb.position, direction * 10.0f, Color.red);

            godData.lr1.SetPositions(CalculateLineRenderPoints(rb.position, direction * 1.0f));
        }

        godData.sphere.position = hitPoint;

    }

    private Vector3[] CalculateLineRenderPoints(Vector3 A, Vector3 B)
    {
        Vector3[] linePoints = new Vector3[10];

        var AB = B - A;

        linePoints[0] = A;

        linePoints[9] = B;

        for (int i = 1; i < 9; i++)
        {
            linePoints[i] = ((float)i / 10.0f) * AB + A;
        }
        return linePoints;
    }

    private Vector3 TransfromsPositionOnTeleport(Transform transform)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 50, 1 << 11))
        {
            return new Vector3( hit.point.x, 0,hit.point.z);
        }
        return Vector3.zero;
    }

    private Vector3 Ray(Rigidbody rb)
    {
        Vector3 pos = rb.position;
        RaycastHit hit;

        Vector3 direction = rb.transform.forward;
        direction = Quaternion.AngleAxis(godData.aimAngleOffset, rb.transform.right) * direction;

        UnityEngine.Debug.DrawLine(pos, direction * 10.0f, Color.green);

        if(Physics.Raycast(pos, direction, out hit, 50, 1 << 11))
        {
            return hit.point;
        }
        return godMaster.transform.position;
    }
    #endregion

    #region Input
    public void MenuSelection(WhichID whichID, float horizontal, float vertical)
    {
        switch (whichID)
        {
            case WhichID.Right:
                if (godData.rightRadialMenu.gameObject.activeInHierarchy)
                    godData.rightRadialMenu.CheckSelection(horizontal, vertical);
                break;
            case WhichID.Left:
                if (godData.leftRadialMenu.gameObject.activeInHierarchy)
                    godData.leftRadialMenu.CheckSelection(horizontal, vertical);
                break;
            default:
                break;
        }
    }

    public void OpenMenu(WhichID whichID)
    {
        switch (whichID)
        {
            case WhichID.Right:
                godData.rightRadialMenu.transform.parent.GetComponent<Canvas>().enabled = true;
                godData.RightControllerStuff.State = ControllerState.Display;
                break;

            case WhichID.Left:
                godData.leftRadialMenu.transform.parent.GetComponent<Canvas>().enabled = true;
                godData.LeftControllerStuff.State = ControllerState.Display;
                break;

        }
    }
    public void CloseMenu(WhichID whichID)
    {
        switch (whichID)
        {
            case WhichID.Right:
                godData.rightRadialMenu.transform.parent.GetComponent<Canvas>().enabled = false;
                switch (godData.RightControllerStuff.State) 
                {
                    case ControllerState.Display:
                        godData.RightControllerStuff.State = godData.RightControllerStuff.PreviousState;
                        break;
                }
                break;

            case WhichID.Left:
                godData.leftRadialMenu.transform.parent.GetComponent<Canvas>().enabled = false;
                switch (godData.LeftControllerStuff.State)
                {
                    case ControllerState.Display:
                        godData.LeftControllerStuff.State = godData.LeftControllerStuff.PreviousState;
                        break;
                }
                break;
        }
    }
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
                    case ControllerState.Display:
                        godData.rightRadialMenu.ExecuteSelectedButton();
                        break;

                }

                break;

            case WhichID.Left:

                switch (godData.LeftControllerStuff.State)
                {

                    case ControllerState.Empty:
                        PickUp(godData.LeftControllerStuff, godData.leftControllerAttach, godData.RightControllerStuff);
                        break;
                    case ControllerState.Display:
                        godData.leftRadialMenu.ExecuteSelectedButton();
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
    #region TrackPad
    public void TrackPadClickDown(WhichID whichID)
    {

        switch (whichID)
        {

            case WhichID.Right:

                switch (godData.RightControllerStuff.State)
                {
                    case ControllerState.Display:
                        godData.rightRadialMenu.ExecuteSelectedButton();
                        break;

                }

                break;

            case WhichID.Left:

                switch (godData.LeftControllerStuff.State)
                {
                    case ControllerState.Display:
                        godData.leftRadialMenu.ExecuteSelectedButton();
                        break;

                }

                break;

        }

    }
    public void TrackPadClickUp(WhichID whichID)
    {

        switch (whichID)
        {

            case WhichID.Right:

                switch (godData.RightControllerStuff.State)
                {

                    case ControllerState.Display:


                        break;

                }

                break;

            case WhichID.Left:

                switch (godData.LeftControllerStuff.State)
                {

                    case ControllerState.Display:


                        break;

                }

                break;

        }

    }
    #endregion

    #endregion

}