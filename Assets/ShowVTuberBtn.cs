using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVTuberBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject vtuber;

    public void turnOnOffVtuber()
    {
        if(vtuber.active == true)
            vtuber.active = false;
        else
            vtuber.active = true;
    }
}
