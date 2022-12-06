using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotationSpikes : MonoBehaviour
{

    private Transform player;
    private GameObject player_obj;
    private bool doOnce = false, spikeMove = false;
    private Transform spike_trans, start_spike_trans;
    private GameObject spike_obj;

    public float upSpeed = 1, leftSpeed = 1;
    private float lspeed = 0;
    public float roateSpeed = 1;
    public float zAngle = 0;

    private GameObject skully_1, skully_2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        player_obj = GameObject.FindWithTag("Player");
        spike_trans = GameObject.Find("spike_left_list_move").transform;
        spike_obj = GameObject.Find("spike_left_list_move");
        start_spike_trans = spike_trans;
        doOnce = false;
        spikeMove = false;

        skully_1 = GameObject.Find("skully_1");
        skully_2 = GameObject.Find("skully_2");

        skully_1.active = false;
        skully_2.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x >= 75 && player.position.x<=78 && player.position.y<=-24 && !doOnce)
        {
            spikeMove = true;
            doOnce = true;
        }
        if(player.position.x >= 69 && player.position.x <= 70 && player.position.y <= -24)
        {
            skully_1.active = true;
            skully_2.active = true;
        }


        if(spikeMove)
        {


            // Debug.Log(spike_trans.position.y);
            if (spike_trans.position.y <= -26.52)
            {
                //spike_trans.Translate(Vector3.up * upSpeed * Time.deltaTime);
                spike_trans.position += Vector3.up * upSpeed * Time.deltaTime;
            }
            else
            {

            //player_obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //Debug.Log(spike_trans.rotation.eulerAngles.z);



            


                float deg = spike_trans.rotation.eulerAngles.z;
                if ((int)deg == 0)
                {
                    //lspeed += leftSpeed;
                    spike_trans.Translate(Vector3.left * leftSpeed * Time.deltaTime, Space.Self);
                    Destroy(spike_obj, 5);
                }
                /*else //(deg < 360 && deg >= 270)
                {
                    zAngle += roateSpeed * Time.deltaTime;
                    spike_trans.Rotate(0, 0, zAngle, Space.Self);
                }*/
                else
                {
                    zAngle += Time.deltaTime * roateSpeed;
                    spike_trans.rotation = Quaternion.RotateTowards(spike_trans.rotation,
                            Quaternion.Euler(spike_trans.rotation.x, spike_trans.rotation.y, 360),
                            zAngle);
                }
            }
        }
                   
    }



}
