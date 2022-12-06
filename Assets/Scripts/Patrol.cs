using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public Transform faceDetection;
    public LayerMask layermask;

    public GameObject healthBar;
    private float distance = 0;

    public float dis = 8;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        distance += speed * Time.deltaTime;

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        RaycastHit2D faceInfo = Physics2D.Raycast(faceDetection.position, Vector2.right, 0.2f, layermask);
        RaycastHit2D faceInfo2 = Physics2D.Raycast(groundDetection.position, Vector2.right, 0.2f, layermask);

        if (/*groundInfo.collider == false || faceInfo.collider == true || faceInfo2.collider == true ||*/ distance>=dis)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                healthBar.transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                healthBar.transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
            distance = 0;
        }
    }
}
