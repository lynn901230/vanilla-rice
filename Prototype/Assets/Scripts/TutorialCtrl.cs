using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCtrl : MonoBehaviour {
	public TutorialSlider TS;

	// Use this for initialization
	void Start () {
		TS = GameObject.Find ("Tutorial").GetComponent<TutorialSlider> ();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (TS.arrow_flag);
		switch(TS.arrow_flag){
		case 0:
			TS.downArrow.transform.localPosition = new Vector3 (-400, -400, 0);
			break;
		case 1:
			TS.downArrow.transform.localPosition = new Vector3 (-55, 200, 0);
			//TS.arrow_flag = 0;
			break;
		case 2:
			TS.downArrow.transform.localPosition = new Vector3 (-330,-150,0);
			TS.arrow_flag = 0;
			break;
		case 3:
			TS.downArrow.transform.localPosition = new Vector3 (-220, -150, 0);
			TS.arrow_flag = 0;
			break;
		}
//		if(TS.arrow_flag == 1){
//			TS.downArrow.transform.localPosition = new Vector3 (-55, 200, 0);
//			TS.arrow_flag = 0;
//		}
	}
}
