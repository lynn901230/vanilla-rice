using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    private MainCamera _maincamera;
    public Slider enemyHPBar;
	public bool attack_flag = false;
    public float enemyhp = 100;
    public float enemy_damage;
    // Use this for initialization
    void Start () {
        _maincamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        enemyHPBar = GameObject.Find("enemyHPSlider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        enemyHPBar.value = enemyhp;
		if (attack_flag == true && enemyhp > 0) 
		{
			Invoke("Attack", .5f);
			attack_flag = false;
		}
	}
    public void Shake(GameObject obj)
    {
        iTween.ShakePosition(obj, iTween.Hash("x", 0.2f, "y", 0.2f, "time", 0.5f));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Object")
        {
			attack_flag = true;
            Destroy(other.gameObject);
            Shake(gameObject);
            enemy_damage = Random.Range(50, 51);
            enemyhp -= enemy_damage;
            GameObject enemydamageUI = Instantiate(Resources.Load("Prefabs/EnemyDamageUI", typeof(GameObject))) as GameObject;
            Destroy(enemydamageUI, 1);
        }
    }

    public void Attack()
    {
        GameObject missile = Instantiate(Resources.Load("Prefabs/missile", typeof(GameObject))) as GameObject;
        missile.AddComponent<Rigidbody>();
        missile.GetComponent<Rigidbody>().useGravity = false;
		missile.GetComponent<Rigidbody>().velocity = transform.forward * 15f;
        _maincamera.button_flag = true;
    }

}
