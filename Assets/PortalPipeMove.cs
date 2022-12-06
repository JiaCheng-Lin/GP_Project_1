using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPipeMove : MonoBehaviour
{
    private Vector3 start;
    public float scale = 1.2f;
    public float dis = 2;
    public Vector3 dir = Vector3.up;
    public bool canMove = true;
    private float timeCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        
    }
   

    // Update is called once per frame
    void Update()
    {
        
        if (canMove)
        {
            timeCnt += Time.deltaTime;
            float l = Mathf.PingPong(timeCnt * scale, dis);

            transform.position = start + dir * l;
        }
        
    }
}
