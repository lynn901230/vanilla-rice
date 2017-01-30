using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumectrl : MonoBehaviour {
    private GameObject BGMslider;
    private GameObject SM;
    // Use this for initialization
    void Start () {
        this.BGMslider = GameObject.Find("BGMSlider");
        this.SM = GameObject.Find("SoundManager");
    }
	
	// Update is called once per frame
	void Update () {
        float BGM = BGMslider.GetComponent<Slider>().value;
        this.SM.GetComponent<SoundManager>().volume.BGM = BGM;
    }
}
