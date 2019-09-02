using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController
{
    private GodData data;
    private GodConfig config;
    private GodMaster master;

    private GodController() { }
    public GodController(GodData data, GodConfig config, GodMaster master)
    {
        this.data = data;
        this.config = config;
        this.master = master;
    }

}
