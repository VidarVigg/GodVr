using UnityEngine;
using System.Collections;

public class GodControllerOld
{

    #region Fields

    private GodMaster godMaster = null;
    private GodConfig godConfig = null;
    private GodData godData = null;

    //For teleporting
    private bool ray = false;

    //For Dragging
    private bool dragging = false;
    private Vector3 grabPoint;
    private Vector3 currentPoint;

    #endregion

    #region Constructors

    private GodControllerOld() { }
    public GodControllerOld(GodMaster godMaster, GodConfig godConfig, GodData godData)
    {
        this.godMaster = godMaster;
        this.godConfig = godConfig;
        this.godData = godData;
    }

    #endregion

    #region Methods

    public void Update()
    {
        if (ray)
            DrawAThing();

        if (dragging)
            MovementDrag();

        currentPoint = godData.rightControllerAttach.transform.position;

    }

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
            Debug.Log("Trigger threshold down");

            grabPoint = Vector3.zero;
            currentPoint = Vector3.zero;
            grabPoint = godData.rightControllerAttach.position;
            dragging = true;

            //For Teleporting Stuff
            //ray = true;
            //godData.anotherTempThing.gameObject.SetActive(true);
            //godData.sphere.gameObject.SetActive(true);

            #region actualCode
            //switch (godData.state)
            //{

            //    //Pick Up
            //    case GodData.PlayerState.EmptyHanded:
            //        //Non Alloc Sphere Cast, Config Radius
            //        GrabObject();

            //        break;

            //    //Grab Display Item
            //    case GodData.PlayerState.InMenu:

            //        if (godData.displayItem)
            //        {
            //            //Close Menu
            //            godData.heldItem = godData.displayItem;
            //            godData.displayItem = null;
            //        }

            //        break;

            //    default:
            //        break;

            //}
            #endregion

        }

        if (inputs[(int)InputOption.Trigger_Threshhold_Up])
        {
            Debug.Log("Trigger threshold up");

            grabPoint = Vector3.zero;
            currentPoint = Vector3.zero;
            dragging = false;

            //For Teleporting Stuff
            //MovementTeleport();
            //ray = false;
            //godData.anotherTempThing.gameObject.SetActive(false);
            //godData.sphere.gameObject.SetActive(false);

            #region actualCode
            //switch (godData.state)
            //{

            //    //Place/Drop
            //    case GodData.PlayerState.HoldingItem:
            //        //Throw/Place/Drop
            //        if (!Place())
            //        {
            //            Throw();
            //        }
            //        break;
            //    case GodData.PlayerState.InMenu:
            //        //Throw/Place/Drop
            //        break;

            //    default:
            //        break;

            //}
            #endregion

        }

    }

    #endregion

    private void Throw()
    {
        Debug.Log("Throw In hand");
        if (godData.heldItem)
        {
            godData.heldItem.Throw(godData.rightControllerPoint);
            godData.heldItem = null;
        }
        godData.state = GodData.PlayerState.EmptyHanded;
    }

    private void GrabObject()
    {
        Debug.Log("Grab Something");
        RaycastHit[] hitted = new RaycastHit[10];


        //Need to make it so depending on which hand that activates it.
        Vector3 position = godData.rightControllerAttach.position;        
        
        
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
            intObj.Grab(godData.rightControllerAttach);
            godData.heldItem = intObj;
        }

        if(godData.heldItem)
        {
            godData.state = GodData.PlayerState.HoldingItem;
        }

    }

    private bool Place()
    {
        if (godData.heldItem)
        {
            Vector3 position = godData.rightControllerAttach.position;
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
        var pos = Vector3.zero;
        Debug.Log("Dragging");
        var vectorDiff = (grabPoint - currentPoint);
        Debug.Log(vectorDiff);
        Debug.DrawLine(grabPoint, currentPoint);

        //godData.cameraRig.transform.position = vectorDiff;
        pos = godData.cameraRig.transform.position + ((grabPoint - currentPoint));
        godData.cameraRig.transform.position = new Vector3(pos.x * 5.0f, godData.cameraRig.transform.position.y, pos.z * 5.0f);
    }

    private void MovementTeleport()
    {
        godData.cameraRig.position = Ray();
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

    private void DrawAThing()
    {
        Vector3 hitPoint = Ray();

        godData.lr1.SetPosition(0, godData.rightControllerAttach.position);

        if (hitPoint != Vector3.zero)
            godData.lr1.SetPosition(1, hitPoint);

        godData.sphere.position = hitPoint;
        
    }

}

//Vector3 startPoint;
//Vector3 currentPoint;
//bool moving;
//public GameObject rig;
//[Range(1.0f, 5.0f)]
//public float moveSpeed = 1.0f;

//private void Awake()
//{
//    trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
//    startPoint = new Vector3(0, 0, 0);
//    currentPoint = new Vector3(0, 0, 0);
//    moving = false;
//}

//private void FixedUpdate()
//{
//    if (spawn.GetStateDown(trackedObj.inputSource))
//    {
//        Debug.Log("Pressed: " + trackedObj.inputSource);
//        startPoint = trackedObj.transform.position;
//        moving = true;
//    }
//    else if (spawn.GetStateUp(trackedObj.inputSource))
//    {
//        Debug.Log("Released: " + trackedObj.inputSource);
//        startPoint = Vector3.zero;
//        currentPoint = Vector3.zero;
//        moving = false;
//    }

//    currentPoint = transform.position;

//    if (moving)
//    {
//        var pos = rig.transform.position + ((startPoint - currentPoint) * moveSpeed);

//        rig.transform.position = new Vector3(pos.x, 0, pos.z);
//    }