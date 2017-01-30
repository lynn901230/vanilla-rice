using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour {
    private GameObject BGMslider;
    private GameObject SM;
    // Use this for initialization
    void Start () {
        this.BGMslider = GameObject.Find("BGMSlider");
        this.SM = GameObject.Find("SoundManager");
        float BGM = this.SM.GetComponent<SoundManager>().volume.BGM;
        BGMslider.GetComponent<Slider>().value = BGM;
    }
}
