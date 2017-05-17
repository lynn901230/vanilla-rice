using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_FadeOutText : MonoBehaviour
{
    public Text enemy_damagetext;
    private float alpha;
    public EnemyController enemyDamage;

    // Use this for initialization
    void Start()
    {
        enemyDamage = GameObject.Find("Enemy").GetComponent<EnemyController>();
        enemy_damagetext = GameObject.Find("EnemyDamageText").GetComponent<Text>();
        enemy_damagetext.text = string.Concat("-", enemyDamage.enemy_damage.ToString());
        Debug.Log(enemy_damagetext.text);
        alpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= 0.8f * Time.deltaTime;
        enemy_damagetext.color = new Color(1, 0, 0, alpha);
    }
}
