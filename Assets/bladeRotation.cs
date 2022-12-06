using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeRotation : MonoBehaviour
{
    public float angle = 1.1f;
    public float bladeSpeed = 2f;

    private float distance = 10;


    private Vector3 start;
    public float scale = 1.2f;
    public float dis = 2;

    private float pre_l=0;


    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float l = Mathf.PingPong(Time.time * scale, dis);
        transform.position = start + Vector3.left * l;

        //Debug.Log(l);


        /*zAngle += angle;
        Debug.Log(zAngle);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, zAngle);*/

        /*distance += bladeSpeed * Time.deltaTime;
        
        if (distance >= 10)
        {
            if (dir == Vector3.left)
                dir = Vector3.right;
            else
                dir = Vector3.left ;
            distance = 0;
        }

        */
        //transform.position += dir * bladeSpeed * Time.deltaTime;
        if ( pre_l - l < 0) 
            transform.Rotate(0, 0, -1*l, Space.Self);
        else
            transform.Rotate(0, 0, l, Space.Self);

        pre_l = l;
    }   
}
