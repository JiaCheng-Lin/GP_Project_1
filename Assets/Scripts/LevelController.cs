using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;

    Monster[] _monsters;
    public float maxTime = 10;
    private float timer = 0;

    void OnEnable()
    {
       // _monsters = FindObjectsOfType<Monster>();    
    }

    // Update is called once per frame
    void Update()
    {
        //if (MonstersAreAllDead())
            //GOToNextLevel();
        if(timer>maxTime)
            GOToNextLevel();
        timer += Time.deltaTime;
    }

    void GOToNextLevel()
    {
        //Debug.Log("Go to level " + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    /*bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }

        return true;
    }*/
}
