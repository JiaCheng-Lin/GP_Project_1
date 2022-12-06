using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlyLittleBird : MonoBehaviour
{
    public float jump_velocity = 1;
    public float horizontal_velocity = 1;
    private Rigidbody2D rb;
    //private bool jump = false; // auto or manual jump.
    public SpriteRenderer bird_render;

    public Rigidbody2D player; // player, bird follow the player

    public float speed = 200f;

    public GrapplingGun GrappGun;

    private bool pre_touch_bird = false;
    private bool auto = true;

    public CinemachineTargetGroup targetGroup; //= GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();

    private bool player_bird_together = false;

    Cinemachine.CinemachineTargetGroup.Target player_tar, bird_tar;

    public GameObject pipeSpawner;
    public GameObject monsterSpawner;
    public GameObject spikesSpawner;
    public GameObject textHint;

    public float player_tar_radius = 7.43f;
    public float bird_tar_radius = 6.0f;

    public bool inRange = false;


    // Start is called before the first frame update
    void Start()
    {
        textHint.SetActive(false) ;
        rb = GetComponent<Rigidbody2D>();
        
        BirdJump();
        InvokeRepeating("BirdJump", 0, 1);
        bird_render.color = (Color)(new Color32(248, 181, 29, 166));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("space") && !auto && player_bird_together) // not auto status
        {
            BirdJump();
        }

        if ((Input.GetKeyDown("t")  || Input.GetKeyDown("space")) && auto && player_bird_together) // go to manual
        {
            CancelInvoke("BirdJump");
            bird_render.color = (Color)(new Color32(255, 255, 255, 255));
            auto = false;
        }
        else if (Input.GetKeyDown("t") && !auto && player_bird_together) // go to auto 
        {
            InvokeRepeating("BirdJump", 0, 1);
            bird_render.color = (Color)(new Color32(248, 181, 29, 166));
            auto = true;
        }

        
        if (pre_touch_bird && !GrappGun.touch_bird && !auto && player_bird_together) // mouse released when bird is muanual controlling
        {
            InvokeRepeating("BirdJump", 0, 1);
            bird_render.color = (Color)(new Color32(248, 181, 29, 166));
            auto = true;
        }

        pre_touch_bird = GrappGun.touch_bird;

        
        float player_position_x = player.transform.position.x;
        float x_diff = player_position_x - rb.position.x;

        // add bird to targetgroup, set cinemachine 
        if (Mathf.Abs(x_diff) < 6 && !player_bird_together)
        {
            // player target
            player_tar.target = player.transform;
            player_tar.weight = 1f;
            player_tar.radius = player_tar_radius;
            targetGroup.m_Targets.SetValue(player_tar, 0);

            // bird target
            bird_tar.target = rb.transform;
            bird_tar.weight = 1f;
            bird_tar.radius = bird_tar_radius;
            targetGroup.m_Targets.SetValue(bird_tar, 1);

            player_bird_together = true; // go to second-half part, show together

            // set pipe and monster spawner activate 
            pipeSpawner.SetActive(true);
            monsterSpawner.SetActive(true);
            spikesSpawner.SetActive(true);
        }
        */

        /*if ((!GrappGun.touch_bird || Mathf.Abs(x_diff) > 5) && player_bird_together) // horizontal move
        {
            Vector2 direction = new Vector2(x_diff, 0).normalized;
            Vector2 force = direction * speed * Time.deltaTime;
            rb.AddForce(force);
        }*/

        ///if (GrappGun.touch_bird/* && player_bird_together*/)
        //{
         //   float bird_y = rb.transform.position.y;
          //  float player_y = player.position.y;
            /*if (player_y >= bird_y-3)
            {
                player.transform.position = new Vector2(player.position.x, bird_y - 3);
            }*/
            
       // }

        /*else if (GrappGun.touch_bird && jump == false) // auto && touched
        {
            Vector2 force = new Vector2(1, 0) * 200.0f * Time.deltaTime;
            rb.AddForce(force);
        }*/
        /*else // do not move (horizontal)
        {
            BirdJump();
        }*/






    }

    void FixedUpdate()
    {
        float x_diff = Mathf.Abs(player.transform.position.x - rb.position.x);
        float y_diff = Mathf.Abs(player.transform.position.y - rb.position.y);
        float dis = Mathf.Sqrt(Mathf.Pow(x_diff, 2) + Mathf.Pow(y_diff, 2));
        //Debug.Log(dis);
        //Debug.Log(x_diff);
        if (dis < 15.0f && x_diff<5.0f)
        {
            textHint.GetComponent<TextMeshPro>().text = "Press \n <sprite index=31>";
            inRange = true;
            textHint.SetActive(true);
        } 
        else
        {
            inRange = false;
            textHint.SetActive(false);
        }
        if (GrappGun.touch_bird)
        {
            textHint.GetComponent<TextMeshPro>().text = "Press <sprite index=31> to release";
            transform.position += Vector3.right * 4 * Time.deltaTime;
            player.transform.position += Vector3.right * 4 * Time.deltaTime;
            //StartCoroutine(ExampleCoroutine());  

        }


        //BirdJump();
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        player.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y - 3);
        
    }

    /*
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("t") && jump == false) // manual
        {
            CancelInvoke("BirdJump");
            bird_render.color = (Color)(new Color32(255, 255, 255, 255));
            jump = true;
            auto = false;
        }
        else if (Input.GetKeyDown("t") && jump) // auto 
        {
            //BirdJump();
            InvokeRepeating("BirdJump", 0, 1);
            bird_render.color = (Color)(new Color32(248, 181, 29, 166));
            jump = false;
            auto = true;
        }


        if (Input.GetKeyDown("space") && jump)
        {
            BirdJump();
        }


        float player_position_x = player.transform.position.x;
        float x_diff = player_position_x - rb.position.x;

        //Debug.Log(player_position_x);
       // Debug.Log(rb.position.x);
        //Debug.Log(Mathf.Abs(x_diff));
       
        if (!GrappGun.touch_bird || Mathf.Abs(x_diff) > 5) // horizontal move
        {
            Vector2 direction = new Vector2(x_diff, 0).normalized;
            Vector2 force = direction * speed * Time.deltaTime;
            rb.AddForce(force);
        }

        if(pre_touch_bird && !GrappGun.touch_bird && !auto)
        {
            InvokeRepeating("BirdJump", 0, 1);
            bird_render.color = (Color)(new Color32(248, 181, 29, 166));
            auto = true;
        }

        pre_touch_bird = GrappGun.touch_bird;
    }*/

    private void BirdJump()
    {
        rb.velocity = Vector2.up * jump_velocity ;
    }




}
