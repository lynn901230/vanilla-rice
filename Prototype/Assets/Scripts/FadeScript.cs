using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeScript : MonoBehaviour {
	public Image fade_obj;
	public float alpha = 1;

	// Use this for initialization
	void Start () {
		fade_obj = GameObject.Find("Girl").GetComponent<Image>();
		fade_obj.color = new Color (0, 0, 0, alpha);
	}
	
	// Update is called once per frame
	void Update () {
		alpha -= 0.8f * Time.deltaTime;
	}
}
