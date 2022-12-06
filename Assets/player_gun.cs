using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_gun : MonoBehaviour
{
    public Camera m_camera;

    public Transform gun_holder;
    public Transform fire_point;

    public GameObject bullet_1;
    public GameObject bullet_2;
    public GameObject bullet_3;
    public GameObject bullet_4;
    public GameObject bullet_5;
    private GameObject select_bullet;
    public GrapplingGun grapplingGun; // check the man whether release the rope

    public void Start()
    {
        select_bullet = bullet_1;
    }

    private void Update()
    {
        RotateToGun();
        PlayerInput();
    }
    void RotateToGun()
    {
        Vector2 distanceVector = (Vector2)m_camera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)gun_holder.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void PlayerInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            select_bullet = bullet_1;
            //Instantiate(bullet_1, fire_point.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            select_bullet = bullet_2;
            //Instantiate(bullet_2, fire_point.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            select_bullet = bullet_3;
            //Instantiate(bullet_3, fire_point.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            select_bullet = bullet_4;
            //Instantiate(bullet_4, fire_point.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            select_bullet = bullet_5;
            //Instantiate(bullet_5, fire_point.position, transform.rotation);
        }

        if(Input.GetKeyUp(KeyCode.Mouse0) && !grapplingGun.touch_bird)
        {
            Instantiate(select_bullet, fire_point.position, transform.rotation);
        }
    }
}

