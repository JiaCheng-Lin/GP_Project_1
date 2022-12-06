using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayerOrder : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] components = GameObject.FindGameObjectsWithTag("ArtMesh");

        //MeshRenderer[] ChildrenMR = this.GetComponentsInChildren(typeof(MeshRenderer)) as MeshRenderer[];
        foreach (GameObject child in components)
        {
            meshRenderer = child.GetComponent<MeshRenderer>();
            meshRenderer.sortingLayerName = "background";
            meshRenderer.sortingOrder = -100;
            /*child.sortingLayerName = "background";
            child.sortingOrder = 0;*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
