using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero_FadeOutText : MonoBehaviour{

    public Text hero_damagetext;
    private float alpha;
    public HeroController heroDamage;

    // Use this for initialization
    void Start()
    {
        heroDamage = GameObject.Find("self").GetComponent<HeroController>();
        hero_damagetext = GameObject.Find("HeroDamageText").GetComponent<Text>();
        hero_damagetext.text = string.Concat("-", heroDamage.hero_damage.ToString());
        Debug.Log(hero_damagetext.text);
        alpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= 0.8f * Time.deltaTime;
        hero_damagetext.color = new Color(1, 0, 0, alpha);
    }
}