using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove : MonoBehaviour
{
    
    public float cloudSpeed = 2f;
    public float moveDis = 10f;

    private Vector3 dir = Vector3.left;
    private float distance = 0f;

    public BlockHit blockhit;

    public SpriteRenderer cloudColor;
    private bool DoOnce = true;

    // Update is called once per frame
    void Update()
    {
        if(blockhit.cloudControl == true)
        {
            distance += cloudSpeed * Time.deltaTime;

            if (distance >= moveDis)
            {
                if (dir == Vector3.left)
                    dir = Vector3.right;
                else
                    dir = Vector3.left;
                distance = 0;
            }

            transform.position += dir * cloudSpeed * Time.deltaTime;
        }

        if(blockhit.cloudControl == true && DoOnce==true)
        {
            cloudColor.color = (Color)(new Color32(255, 255, 255, 255));
            DoOnce = false;
        }
        
    }
}
