using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeTopMove : MonoBehaviour
{

    private  GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("111");
            player.transform.parent = this.transform;



           /* player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<CharacterController2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; // to freeze player in place
            player.GetComponent<throwhook>().enabled = false; // prevent player from use grappling hook while dead
            //player.GetComponent<Renderer>().enabled = false;

            // set sorting layer and order
            //player.GetComponent<SpriteRenderer>().sortingLayerName = "background";
            // player.GetComponent<SpriteRenderer>().sortingOrder = 34;

            //player.GetComponent<GrappleRope>().enabled = false;
            //player.GetComponent<SpringJoint2D>().enabled = false;
            gunPivot.SetActive(false);

            player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f); // decrease alpha value

            player.GetComponent<BoxCollider2D>().enabled = false; // prevent further collisions
            player.GetComponent<CircleCollider2D>().enabled = false;*/
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player.transform.parent = null;
        

        /*player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; // to freeze player in place
        player.GetComponent<throwhook>().enabled = true; ; // prevent player from use grappling hook while dead
        //player.GetComponent<Renderer>().enabled = false;


        player.GetComponent<BoxCollider2D>().enabled = false; // prevent further collisions
        player.GetComponent<CircleCollider2D>().enabled = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
