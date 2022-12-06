using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator right_run;

    void Start()
    {
        right_run = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            right_run.Play("", 0, 0f);
            
            
        }



    }
}
