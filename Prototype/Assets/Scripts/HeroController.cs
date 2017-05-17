using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour {

    private MainCamera maincamera;
    public Slider heroHPBar;
    public float herohp = 100;
    public float hero_damage;
    // Use this for initialization
    void Start () {
        heroHPBar = GameObject.Find("SelfHPSlider").GetComponent<Slider>();
        maincamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
	}

    // Update is called once per frame
    void Update()
    {
        heroHPBar.value = herohp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Missile")
        {
            Destroy(collision.gameObject);
            Shake(maincamera.gameObject);
            hero_damage = Random.Range(20, 36);
            herohp -= hero_damage;
            GameObject herodamageUI = Instantiate(Resources.Load("Prefabs/HeroDamageUI", typeof(GameObject))) as GameObject;
            Destroy(herodamageUI, 1);
        }
    }

    public void Shake(GameObject obj)
    {
        iTween.ShakePosition(obj, iTween.Hash("x", 0.05f, "y", 0.05f, "time", 0.5f));
    }
}
