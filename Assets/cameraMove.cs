using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    private new Camera camera;
    private Transform player;

    public PlayerMovement playMove;
    
    private void Awake()
    {
        camera = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").transform;
    }

    
    private void LateUpdate()
    {
        // track the player moving to the right
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x; // Mathf.Max(cameraPosition.x, player.position.x);
        //cameraPosition.y = player.position.y + 5;

        if (player.position.y >= 3) // higher
        {
            cameraPosition.y = player.position.y;
        }
        else if (player.position.y < 3 && player.position.y > -3) // floor 1
        {
            cameraPosition.y = 3;
        }
        else if (player.position.y < -3)
        {
            cameraPosition.y = player.position.y + 6;
        }
        /*else if (player.position.y <= -3  && playMove.b1Check == false) // b1
        {
            cameraPosition.y = player.position.y+6;
        }
        else if(playMove.b1Check == true && player.position.y >-12) // down to up 
        {
            cameraPosition.y = player.position.y;
        }*/

            //Debug.Log(playMove.b1Check);

        transform.position = cameraPosition;
    }
}

