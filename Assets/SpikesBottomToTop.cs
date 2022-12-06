using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpikesBottomToTop : MonoBehaviour
{
    public GameObject player; // get player position
    public TMP_Text warning_text;
    public float spikesSpeed = 10f;
    private float player_x;
    private float player_horizontal;

    // Start is called before the first frame update
    void Start()
    {
        warning_text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        player_x = player.transform.position.x;

        player_horizontal = Input.GetAxis("Horizontal");

        if (player_x > -40) // right
        {
            warning_text.enabled = false;
            warning_text.text = "";
        }

        else if(player_x <= -40 && player_x > -55 )
    {
            warning_text.enabled = true;
            warning_text.fontSize = 47;
            warning_text.text = "Wrong area\nplease keep going right!!!";
        }

        else if (player_x <= -55 && player_x >= -70 ) // left
        {
            warning_text.enabled = true;
            warning_text.fontSize = 52;
            warning_text.text = "Last warning!!!\nplease keep going right!!!";
        }
        else if(player_x <= -75)
        {
            warning_text.enabled = true;
            warning_text.fontSize = 52;
            warning_text.text = "congratulations!!!\nbut there is nothing here";
        }
        

        if(player_x <= -67)
        {
            transform.position += Vector3.up * spikesSpeed * Time.deltaTime;
        }




    }
}
