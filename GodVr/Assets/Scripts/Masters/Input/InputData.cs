using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class InputData
{

    #region Fields

    [SerializeField]
    private BitArray rightBitArray = null;

    [SerializeField]
    private BitArray leftBitArray = null;

    [SerializeField]
    private float leftTrigger = 0f;

    [SerializeField]
    private float rightTrigger = 0f;

    [SerializeField]
    private float rightTrackpadHorizontal = 0f;

    [SerializeField]
    private float rightTrackpadVertical = 0f;

    [SerializeField]
    private float leftTrackpadHorizontal = 0f;

    [SerializeField]
    private float leftTrackpadVertical = 0f;

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

    public float LeftTrigger
    {
        get { return leftTrigger; }
        set { leftTrigger = value; }
    }

    public float RightTrigger
    {
        get { return rightTrigger; }
        set { rightTrigger = value; }
    }

    public float RightTrackpadHorizontal
    {
        get { return rightTrackpadHorizontal; }
        set { rightTrackpadHorizontal = value; }
    }

    public float RightTrackpadVertical
    {
        get { return rightTrackpadVertical; }
        set { rightTrackpadVertical = value; }
    }

    public float LeftTrackpadHorizontal
    {
        get { return leftTrackpadHorizontal; }
        set { leftTrackpadHorizontal = value; }
    }

    public float LeftTrackpadVertical
    {
        get { return leftTrackpadVertical; }
        set { leftTrackpadVertical = value; }
    }

    #endregion

}