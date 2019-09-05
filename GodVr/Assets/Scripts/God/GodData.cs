using UnityEngine;
using System;
[Serializable]
public class GodData 
{
    [SerializeField] private ResourceStruct[] gatheredResources;

    public InteractableWorldObject rock;
    public InteractableWorldObject displayItem = null;
    public InteractableWorldObject heldItem = null;

    public Transform rightControllerAttach;
    public Transform leftControllerAttach;

    public enum PlayerState
    {
        EmptyHanded,
        HoldingItem,
        InMenu
    }

    public PlayerState state = PlayerState.EmptyHanded;

}
