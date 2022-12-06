using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterGateCheck : MonoBehaviour
{
    public Transform ExitGate;

    public KeyCode enterKeyCode = KeyCode.F;
    public Vector3 enterDirection = Vector3.left;
    public Vector3 exitDirection = Vector3.up;
    // public GameObject SpikeB
    private bool canTrans = false;

    public Transform player;
    public GameObject playerObj;
    private Vector3 enterPosition, exitPosition,  enteredScale;

     private void OnCollisionEnter2D(Collision2D collision)
     {
        
        if (collision.gameObject.CompareTag("Player"))
         {
            if (Input.GetKey(enterKeyCode))
             {
                Debug.Log(canTrans);
                playerObj.GetComponent<Rigidbody2D>().isKinematic = true;
                playerObj.GetComponent<CircleCollider2D>().enabled = false;
                playerObj.GetComponent<BoxCollider2D>().enabled = false;
                enterPosition = player.transform.position;
                exitPosition = ExitGate.position;
                canTrans = true;
                //StartCoroutine(GotoExit(collision.transform));
            }
         }
     }

    private IEnumerator GotoExit(Transform player)
    {
        enterPosition = player.transform.position;
        exitPosition = ExitGate.position;

        //player.GetComponent<PlayerMovement>().enabled = false;
        enteredScale = Vector3.one * 0.5f;

        yield return MovePlayer(player, enterPosition, exitPosition, enteredScale);
    }
    private IEnumerator MovePlayer(Transform player, Vector3 enterPosition, Vector3 exitPosition, Vector3 enteredScale)
    {
        canTrans = true;


        yield return null;

        /*float elapsed = 0f;
        float duration = 1f;

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
        player.localScale = endScale;*/
    }

    private void Update()
    {
        
        if(canTrans)
        {
            //if (player.position.x <= exitPosition.x ) // move to enterDirection
            //{
                //player.Translate(enterDirection * 2 * Time.deltaTime);
            player.position = Vector3.MoveTowards(enterPosition, exitPosition, 1 * Time.deltaTime);
            //}
        }
    }

    /*private IEnumerator Enter(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        Vector3 enteredPosition = transform.position; // + enterDirection;
        Vector3 enteredScale = Vector3.one * 0.5f;

        yield return Move(player, enteredPosition, enteredScale);
        yield return new WaitForSeconds(1f);

        //var sideSrolling = Camera.main.GetComponent<SideScrolling>();
        //sideSrolling.SetUnderground(this.transform.position.y < sideSrolling.undergroundThreshold);

        if (exitDirection != Vector3.zero)
        {
            player.position = connection.transform.position - exitDirection;
            yield return Move(player, connection.transform.position + exitDirection, Vector3.one);
        }
        else
        {
            player.position = connection.transform.position;
            player.localScale = Vector3.one;
        }

        player.GetComponent<PlayerMovement>().enabled = true;
    }

    private IEnumerator Move(Transform player, Vector3 endPosition, Vector3 endScale)
    {
        float elapsed = 0f;
        float duration = 1f;

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
    }*/



}
