using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawner : MonoBehaviour
{
    //public float maxTime = 100;
    //private float timer = 0;
    public GameObject monster;
    public float height;
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("Generate_monster", 0, 5);
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (timer > maxTime)
        {
            GameObject newMonster = Instantiate(monster);
            newMonster.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newMonster, 70);
            timer = 0;
        }
        timer += Time.deltaTime;
    }*/

    void Generate_monster()
    {
        GameObject newMonster = Instantiate(monster);
        newMonster.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        Destroy(newMonster, 70);
    }
}
