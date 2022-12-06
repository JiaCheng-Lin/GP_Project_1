using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRainSpawner : MonoBehaviour
{
    public GameObject woodSpike;
    public float range = 0.15f;
    public BlockHit blockhit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (blockhit.cloudControl == true && !IsInvoking("Generate_SpikeRain")) // do once
        {
            InvokeRepeating("Generate_SpikeRain", 0, 0.5f);

        }
        else if (blockhit.cloudControl == false && IsInvoking("Generate_SpikeRain")) // do once
        {
            CancelInvoke("Generate_SpikeRain");
        }
    }

    void Generate_SpikeRain()
    {
        GameObject newWoodSpike = Instantiate(woodSpike);
        newWoodSpike.transform.position = transform.position + new Vector3(Random.Range(-range, range), 0, 0); 
        Destroy(newWoodSpike, 7);
    }
}
