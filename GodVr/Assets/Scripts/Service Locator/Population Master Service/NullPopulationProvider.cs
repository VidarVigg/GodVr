using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullPopulationProvider : ISessionMasterService
{
    public int Population { get; set; }

    public void ChangePopulationCount(ValueModifier modifier, int amt)
    {
        Debug.Log("null population provider");
    }

}
