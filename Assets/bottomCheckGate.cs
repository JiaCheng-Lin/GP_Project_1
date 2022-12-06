using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomCheckGate : MonoBehaviour
{
    private GameObject player;
    public GameObject gunPivot;
    public GameObject text;

    private bool canEnter = false;

    public Transform startP, targetP;
    private bool startTrans = false;
    public PortalPipeMove portalPipe;
    public portalPipeSwitch switchHitCnt;
    public float vertical_speed = 10.0f, hor_speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") /*&& collision.transform.DotTest(transform, Vector2.down)*/)
        {
            //ContactPoint2D contact = collision.contacts[0];
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            //Debug.Log(rot); // top side touched: (1.00000, 0.00000, 0.00000, 0.00000)

            //player.transform.parent = this.transform;
            canEnter = true;
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //player.transform.parent = null;


        /*player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; // to freeze player in place
        player.GetComponent<throwhook>().enabled = true; ; // prevent player from use grappling hook while dead
        //player.GetComponent<Renderer>().enabled = false;


        player.GetComponent<BoxCollider2D>().enabled = false; // prevent further collisions
        player.GetComponent<CircleCollider2D>().enabled = false;*/
        canEnter = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (canEnter)
        {
           text.SetActive(true);
        }
        else
        {
            text.SetActive(false) ;
        }

        if (canEnter && Input.GetKeyDown("a")) // just do once
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<CharacterController2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; // to freeze player in place
            player.GetComponent<throwhook>().enabled = false; // prevent player from use grappling hook while dead
                                                              //player.GetComponent<Renderer>().enabled = false;

            // set sorting layer and order
            player.GetComponent<SpriteRenderer>().sortingLayerName = "background";
            player.GetComponent<SpriteRenderer>().sortingOrder = 34;

            //player.GetComponent<GrappleRope>().enabled = false;
            //player.GetComponent<SpringJoint2D>().enabled = false;
            gunPivot.SetActive(false);

            //player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f); // decrease alpha value

            player.GetComponent<BoxCollider2D>().enabled = false; // prevent further collisions
            player.GetComponent<CircleCollider2D>().enabled = false;

            if (portalPipe.canMove)   // stop it
                switchHitCnt.Hit();

            StartCoroutine(Enter(player.transform, Vector3.left, 0.5f));

            startTrans = true;

        }
        if (startTrans)
        {

            if (player.transform.position.y <= targetP.position.y - 3 && player.transform.position.y >= targetP.position.y - 5)
            {
                player.transform.localScale = Vector3.one*1.1f;
            }

            if (player.transform.position.x >= targetP.position.x)
            {
                //player.transform.localScale = Vector3.one / 2;
                player.transform.position += Vector3.left * hor_speed * Time.deltaTime;
            }
                
            else if (player.transform.position.y <= targetP.position.y + 3)
            {
                
                player.transform.position += Vector3.up * vertical_speed * Time.deltaTime;
            }
            
            else
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                player.GetComponent<CharacterController2D>().enabled = true;
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; // to freeze player in place
                player.GetComponent<throwhook>().enabled = true; // prevent player from use grappling hook while dead
                                                                 //player.GetComponent<Renderer>().enabled = false;

                // set sorting layer and order
                player.GetComponent<SpriteRenderer>().sortingLayerName = "default";
                player.GetComponent<SpriteRenderer>().sortingOrder = 0;

                //player.GetComponent<GrappleRope>().enabled = false;
                //player.GetComponent<SpringJoint2D>().enabled = false;
                gunPivot.SetActive(true);

                //player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f); // decrease alpha value

                player.GetComponent<BoxCollider2D>().enabled = true; // prevent further collisions
                player.GetComponent<CircleCollider2D>().enabled = true;

                switchHitCnt.Hit();

                startTrans = false;
            }
        }

    }

    private IEnumerator Enter(Transform player, Vector3 dir, float scale)
    {
        Vector3 enteredPosition = startP.position + dir;
        Vector3 enteredScale = Vector3.one * scale;
        yield return Move(player, enteredPosition, enteredScale);
    }
    private IEnumerator Move(Transform player, Vector3 endPosition, Vector3 endScale)
    {
        float elapsed = 0f;
        float duration = 0.4f;

        Vector3 startPosition = player.position;
        Vector3 startScale = player.localScale;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            player.position = Vector3.Lerp(startPosition, endPosition, t);
            player.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        player.position = endPosition;
        player.localScale = endScale;
    }
}
