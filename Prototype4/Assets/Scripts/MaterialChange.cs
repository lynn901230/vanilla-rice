using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour {

    public Material[] _material;           // 割り当てるマテリアル. 
    private MainCamera _clicked_obj;
    // Use this for initialization 
    void Start()
    {
        _clicked_obj = GameObject.Find("Main Camera").GetComponent<MainCamera>();
    }

    // Update is called once per frame 
    void Update()
    {
        if (_clicked_obj.objectName == gameObject.name)
        {
            this.GetComponent<Renderer>().material = _material[1];
        }
        else
        {
            this.GetComponent<Renderer>().material = _material[0];
        }

    }
}
