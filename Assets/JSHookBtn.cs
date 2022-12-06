using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JSHookBtn : MonoBehaviour
{
    public bool btn = true;
    public Sprite onImage, offImage;

    public void controlBtn ()
    {
        if (btn)
        {
            btn = false;
            this.gameObject.GetComponent<Image>().sprite = offImage;
        }
        else
        {
            btn = true;
            this.gameObject.GetComponent<Image>().sprite = onImage;
        }
    }
}
