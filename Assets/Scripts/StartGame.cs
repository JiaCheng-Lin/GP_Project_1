using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public int scenceNumber = 1;
    // Start is called before the first frame update
    public void Startmenu() {


        // Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(scenceNumber); // need go to File->Build settings. the index(number) mean scene idx

    }
}
