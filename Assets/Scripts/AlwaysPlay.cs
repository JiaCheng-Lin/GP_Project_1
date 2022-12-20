using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysPlay : MonoBehaviour
{
    static AlwaysPlay _instance;
    public static AlwaysPlay instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AlwaysPlay>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    private void Awake() 
    {
    	//此脚本永不销毁，并且每次进入初始场景时进行判断，若存在重复的则销毁
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != _instance)
        {
            Destroy(gameObject);
        }
    }
}
