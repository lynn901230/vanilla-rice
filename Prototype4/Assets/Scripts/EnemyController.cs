using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public Slider enemyHPBar;
    public float enemyhp = 100;
    public float enemy_damage;
    // Use this for initialization
    void Start () {
        enemyHPBar = GameObject.Find("enemyHPSlider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        enemyHPBar.value = enemyhp;
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject missile = Instantiate(Resources.Load("Prefabs/missile", typeof(GameObject))) as GameObject;
            missile.AddComponent<Rigidbody>();
            missile.GetComponent<Rigidbody>().useGravity = false;
            missile.GetComponent<Rigidbody>().velocity = transform.right * 15f;
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
            Destroy(other.gameObject);
            Shake(gameObject);
            enemy_damage = Random.Range(50, 51);
            enemyhp -= enemy_damage;
            GameObject enemydamageUI = Instantiate(Resources.Load("Prefabs/EnemyDamageUI", typeof(GameObject))) as GameObject;
            Destroy(enemydamageUI, 1);           
        }
    }

}
