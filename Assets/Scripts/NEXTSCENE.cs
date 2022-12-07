using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NEXTSCENE : MonoBehaviour
{

    public void StartMenu() {


        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
}
