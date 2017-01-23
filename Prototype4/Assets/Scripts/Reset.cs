using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;


public class Reset : MonoBehaviour
{
    private MainCamera maincamera;

    public void OnClick()
    {
        maincamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        GameObject destroytarget;

        destroytarget = GameObject.Find("object1");
        Destroy(destroytarget);
        GameObject desk = Instantiate(Resources.Load("Prefabs/desk02-test", typeof(GameObject))) as GameObject;
        desk.transform.position = new Vector3(1, 0, 0);
        desk.name = "object1";
        desk.AddComponent<Rigidbody>();
        desk.AddComponent<BoxCollider>();
        maincamera.targetObject = desk;

        GameObject enemy2 = GameObject.Find("enemy2");
        enemy2.name = "enemy2";
        enemy2.GetComponent<Renderer>().material.color = Color.blue;
        enemy2.transform.position = new Vector3(3, 1, 0);
        enemy2.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        enemy2.GetComponent<Rigidbody>().mass = 100;
        maincamera.enemy2 = enemy2;

    }
}
