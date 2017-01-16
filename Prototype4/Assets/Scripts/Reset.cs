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

        GameObject destroytarget = GameObject.Find("object1");
        Destroy(destroytarget);
        GameObject chair = Instantiate(Resources.Load("Prefabs/Chair", typeof(GameObject))) as GameObject;
        chair.transform.position = new Vector3(-4, 2, -4);
        chair.name = "object1";
        chair.AddComponent<Rigidbody>();
        chair.AddComponent<BoxCollider>();

        destroytarget = GameObject.Find("object2");
        Destroy(destroytarget);
        GameObject desk = Instantiate(Resources.Load("Prefabs/Desk", typeof(GameObject))) as GameObject;
        desk.transform.position = new Vector3(4, 2, -4);
        desk.name = "object2";
        desk.AddComponent<Rigidbody>();
        desk.AddComponent<BoxCollider>();
        //destroytarget = GameObject.Find("desk01");
        //Destroy(destroytarget);
        //GameObject desk = GameObject.Find("desk01");
        maincamera.targetObject = desk;

        destroytarget = GameObject.Find("enemy1");
        Destroy(destroytarget);
        GameObject enemy1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy1.name = "enemy1";
        enemy1.GetComponent<Renderer>().material.color = Color.blue;
        enemy1.transform.position = new Vector3(-4, 2, 4);
        enemy1.AddComponent<Rigidbody>();
        maincamera.enemy1= enemy1;

        destroytarget = GameObject.Find("enemy2");
        Destroy(destroytarget);
        GameObject enemy2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy2.name = "enemy2";
        enemy2.GetComponent<Renderer>().material.color = Color.blue;
        enemy2.transform.position = new Vector3(4, 2, 4);
        enemy2.AddComponent<Rigidbody>();
        maincamera.enemy2 = enemy2;

        Destroy(destroytarget);
    }
}
