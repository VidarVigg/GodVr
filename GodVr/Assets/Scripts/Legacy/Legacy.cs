namespace Legacy
{

    public class LegacyClass
    {

        #region God Input

        //public void HandleInput(BitArray inputs)
        //{
        //    //for (int i = 0; i < inputs.Length; i++)
        //    //{
        //    //    Debug.Log(i + " = " + inputs[i]);
        //    //}

        //    //Touch/Click Button (Personal Preference, Options Bool)
        //    if (inputs[(int)InputOption.TouchTrackpad_Down])
        //    {

        //        switch (godData.state)
        //        {

        //            //Open Menu
        //            case GodData.PlayerState.InMenu:

        //                if (!godData.heldItem)
        //                {
        //                    godData.displayItem = GodMaster.Instantiate(godData.rock);
        //                }

        //                break;

        //            default:
        //                break;

        //        }

        //    }


        //    if (inputs[(int)InputOption.TouchTrackpad_Up])
        //    {

        //        switch (godData.state)
        //        {

        //            //Close Menu
        //            case GodData.PlayerState.InMenu:

        //                break;

        //            default:
        //                break;

        //        }

        //        if (godData.displayItem)
        //        {
        //            GodMaster.Destroy(godData.displayItem.gameObject);
        //            godData.displayItem = null;
        //        }

        //    }

        //    if (inputs[(int)InputOption.Trigger_Threshhold_Down])
        //    {

        //        switch (godData.state)
        //        {

        //            //Pick Up
        //            case GodData.PlayerState.EmptyHanded:
        //                //Non Alloc Sphere Cast, Config Radius
        //                //GrabObject();

        //                break;

        //            //Grab Display Item
        //            case GodData.PlayerState.InMenu:

        //                if (godData.displayItem)
        //                {
        //                    //Close Menu
        //                    godData.heldItem = godData.displayItem;
        //                    godData.displayItem = null;
        //                }

        //                break;

        //            default:
        //                break;

        //        }

        //    }

        //    if (inputs[(int)InputOption.Trigger_Threshhold_Up])
        //    {

        //        switch (godData.state)
        //        {

        //            //Place/Drop
        //            case GodData.PlayerState.HoldingItem:
        //                //Throw/Place/Drop
        //                //if (!Place())
        //                //{
        //                //    //Throw();
        //                //}
        //                break;
        //            case GodData.PlayerState.InMenu:
        //                //Throw/Place/Drop
        //                break;

        //            default:
        //                break;

        //        }

        //    }

        //}

        #endregion

        #region Throw

        //private void Throw(WhichID whichID)
        //{
        //    Debug.Log("Throw In hand");
        //    if (godData.heldItem)
        //    {

        //        switch (whichID)
        //        {
        //            case WhichID.Right:
        //                godData.heldItem.Throw(godData.rightControllerPoint);
        //                break;

        //            case WhichID.Left:
        //                godData.heldItem.Throw(godData.leftControllerPoint);
        //                break;
        //        }


        //        godData.heldItem = null;
        //    }
        //    godData.state = GodData.PlayerState.EmptyHanded;
        //}

        #endregion

        #region Grab

        //private void GrabObject(WhichID whichID)
        //{
        //    Debug.Log("Grab Something");
        //    RaycastHit[] hitted = new RaycastHit[10];


        //    Vector3 position = Vector3.zero;

        //    switch (whichID)
        //    {

        //        case WhichID.Right:
        //            position = godData.rightControllerAttach.position;
        //            break;

        //        case WhichID.Left:
        //            position = godData.leftControllerAttach.position;
        //            break;

        //    }

        //    //Need to make it so depending on which hand that activates it.


        //    //Put this in Config
        //    int layerMask = 1 << 9;

        //    int numberOfHits = Physics.SphereCastNonAlloc(position, godData.RayCastSphereRadius, Vector3.down, hitted, layerMask);

        //    if (numberOfHits < 1)
        //    {
        //        return;
        //    }
        //    int nearestHitIndex = 0;


        //    for (int i = 0; i < numberOfHits; i++)
        //    {
        //        Debug.Log(hitted[i].collider.gameObject, hitted[i].collider.gameObject);
        //        if (hitted[nearestHitIndex].distance < hitted[i].distance)
        //        {
        //            continue;
        //        }
        //        nearestHitIndex = i;

        //    }
        //    InteractableWorldObject intObj = hitted[nearestHitIndex].transform.GetComponent<InteractableWorldObject>();
        //    //Debug.Log(intObj);
        //    if (intObj)
        //    {
        //        switch (whichID)
        //        {

        //            case WhichID.Right:
        //                intObj.Grab(godData.rightControllerAttach);
        //                break;

        //            case WhichID.Left:
        //                intObj.Grab(godData.leftControllerAttach);
        //                break;

        //        }

        //        godData.heldItem = intObj;
        //    }

        //    if (godData.heldItem)
        //    {
        //        godData.state = GodData.PlayerState.HoldingItem;
        //    }

        //}

        #endregion

        #region Place

        //private bool Place(WhichID whichID)
        //{
        //    if (godData.heldItem)
        //    {

        //        Vector3 position = Vector3.zero;

        //        switch (whichID)
        //        {

        //            case WhichID.Right:
        //                position = godData.rightControllerAttach.position;
        //                break;

        //            case WhichID.Left:
        //                position = godData.rightControllerAttach.position;
        //                break;

        //        }

        //        RaycastHit hit;
        //        if (Physics.Raycast(position, Vector3.down, out hit, godData.RayPlaceDistance, 1 << 8))
        //        {
        //            godData.heldItem.Place(hit.point, Quaternion.identity);
        //            godData.heldItem = null;
        //            godData.state = GodData.PlayerState.EmptyHanded;
        //            Debug.Log("Placed Item");
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        #endregion

        #region Trigger Down State Stuff

        //switch (godData.state)
        //{

        //    //Pick Up
        //    case GodData.PlayerState.EmptyHanded:
        //        //Non Alloc Sphere Cast, Config Radius
        //        Grab(whichID);

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

        #endregion

        #region Trigger Up State Stuff

        //switch (godData.state)
        //    {

        //        //Place/Drop
        //        case GodData.PlayerState.HoldingItem:
        //            //Throw/Place/Drop
        //            if (!Place(whichID))
        //            {
        //                Throw(whichID);
        //}
        //            break;
        //        case GodData.PlayerState.InMenu:
        //            //Throw/Place/Drop
        //            break;

        //        default:
        //            break;

        #endregion

    }

}