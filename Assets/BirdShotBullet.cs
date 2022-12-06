using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShotBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")) 
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
}
