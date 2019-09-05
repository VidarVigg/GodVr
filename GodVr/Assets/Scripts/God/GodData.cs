using UnityEngine;
using System;
using Valve.VR;

[Serializable]
public class GodData 
{
    [SerializeField] private ResourceStruct[] gatheredResources;

    public InteractableWorldObject rock;
    public InteractableWorldObject displayItem = null;
    public InteractableWorldObject heldItem = null;

    public Rigidbody rightControllerAttach;
    public Rigidbody leftControllerAttach;
    public SteamVR_Behaviour_Pose rightControllerPoint;
    public SteamVR_Behaviour_Pose leftControllerPoint;

    public float RayCastSphereRadius = 0.5f;
    public float RayPlaceDistance = 0.5f;

    public enum PlayerState
    {
        EmptyHanded,
        HoldingItem,
        InMenu
    }

    public PlayerState state = PlayerState.EmptyHanded;

}
