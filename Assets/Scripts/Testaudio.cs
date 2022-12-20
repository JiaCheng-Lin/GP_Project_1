using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testaudio : MonoBehaviour
{
    public GameObject objPrefabInstantSource;//音乐预知物体 
    private GameObject musicInstant = null;//场景中是否有这个物体  
    // Use this for initialization  
    void Start()
    {
        musicInstant = GameObject.FindGameObjectWithTag("sounds");
        if (musicInstant == null)
        {
            musicInstant = (GameObject)Instantiate(objPrefabInstantSource);
        }
    }
    void OnGUI()
    {
        if (GUILayout.Button("Load Level"))
        {
            if (Application.loadedLevelName == "001")//关于这个下面有详细介绍  
            {
                Application.LoadLevel("002");
            }
            else
            {
                Application.LoadLevel("001");
            }
        }
    }
}