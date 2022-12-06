using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.VersionControl;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float airSpeed = 60f;
    public float groundSpeed = 40f;
    public bool jump = false;
    public bool crouch = false;
    public Animator animator;
    public int crystals;
    public int keys;
    public int goldCoins;

    public JSHook jshook;
    public JSHookBtn VTuberBtn;
    // public throwhook hook;

    public bool b1Check = false, floor1Check = false;

    public GrapplingGun GG;

    // Start is called before the first frame update
    void Start()
    {
        //audioManager = FindObjectOfType<AudioManager>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground_b1")
        {
            b1Check = true;
            floor1Check = false;
        }
        else if (collision.gameObject.name == "Ground1_1" || collision.gameObject.name == "Ground1_2")
        {
            b1Check = false;
            floor1Check = true;
        }

        if (GG.touch_bird && collision.gameObject.tag != "yellowBird")
        {
            GG.touch_bird = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Input.GetAxisRaw("Horizontal");
        var input = Input.GetAxisRaw("Horizontal");
        var js_yaw = -1 * jshook.yaw;
        if (jshook && VTuberBtn.btn)
        {
            if (js_yaw >= 12 || input==1) dir = 1;
            else if (js_yaw <= -12 || input ==-1) dir = -1;
            else dir = 0;
        }
        horizontalMove = dir * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")/*&& hook.canJump*/)
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }
        else if(jshook && jshook.pitch>=8 && VTuberBtn.btn)
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }

        /*if (Input.GetKeyDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }*/
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        runSpeed = groundSpeed;
    }
    void FixedUpdate()
    {

        if (!controller.m_Grounded)
        {
            runSpeed = airSpeed;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
