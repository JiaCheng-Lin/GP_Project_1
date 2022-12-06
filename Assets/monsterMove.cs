using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocity = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Z))
            rb.velocity = Vector2.left * velocity + new Vector2(0.0f, -0.6f);
        if (Input.GetKey(KeyCode.C))
            rb.velocity = Vector2.right * velocity + new Vector2(0.0f, -0.6f);*/
    }
}
