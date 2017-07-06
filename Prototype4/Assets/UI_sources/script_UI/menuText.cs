using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class menuText : MonoBehaviour {
    public Text menutext;
	int S,T;
    string[] str = { "お疲れさま！今日は何があった？", "これから何をしよっか？", "ちょこっと休憩したいかも","もう保健室に戻る？","コードの扱いはもう慣れた？","おはよう！","もうお昼だね","そろそろ寝なきゃダメだよ","明日もよろしくね！" };
        // Use this for initialization
    void Start() {
        menutext.text = str[0];
		S = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
		{
			T = UnityEngine.Random.Range (0, 9);
			if (S != T) {
				menutext.text = str [T];
			}
        }
    }
}
