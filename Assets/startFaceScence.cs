using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startFaceScence : MonoBehaviour
{
    // Start is called before the first frame update
    public void Startmenu()
    {


        // Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(2); // need go to File->Build settings. the index(number) mean scene idx

    }
}
