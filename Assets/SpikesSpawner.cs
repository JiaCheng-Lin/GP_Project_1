using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesSpawner : MonoBehaviour
{
    public GameObject spikes;

    // Start is called before the first frame update
    void Start()
    {
       // InvokeRepeating("Generate_spikes", 0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Generate_spikes()
    {
        GameObject newSpikes = Instantiate(spikes);
        newSpikes.transform.position = transform.position;
        Destroy(newSpikes, 70);
    }
}
