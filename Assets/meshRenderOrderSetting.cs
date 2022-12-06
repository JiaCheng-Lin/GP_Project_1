using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshRenderOrderSetting : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "background";
        meshRenderer.sortingOrder = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
