using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuText : MonoBehaviour {
    public Text menutext;
    string[] str = { "お疲れさま！今日は何があった？", "これから何をしよっか？", "ちょこっと休憩したいかも" };
        // Use this for initialization
    void Start() {
        menutext.text = str[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            menutext.text = str[UnityEngine.Random.Range(0, 3)];
        }
    }
}
