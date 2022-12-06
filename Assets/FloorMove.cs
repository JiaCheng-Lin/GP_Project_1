using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("111");
            player.transform.parent = this.transform;
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        player.transform.parent = null;
    }

}
