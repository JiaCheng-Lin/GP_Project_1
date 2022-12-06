using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleSpikeMove : MonoBehaviour
{
    private Vector3 start;
    public float scale=1.2f;
    public float dis = 2;
    public Vector3 dir = Vector3.up; 

    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float l = Mathf.PingPong(Time.time*scale, dis);

        transform.position = start + dir * l;

    }
}
