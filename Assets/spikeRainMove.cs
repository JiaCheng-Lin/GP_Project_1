using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeRainMove : MonoBehaviour
{
    public float speed = 3;
    // Start is called before the first frame update


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            StartCoroutine(disappear()); // if collision happened
        
    }

    IEnumerator disappear()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false); // monster disappear
    }

    void FixedUpdate()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
