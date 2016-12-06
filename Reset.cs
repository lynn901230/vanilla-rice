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
        GameObject object1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        object1.name = "object1";
        object1.transform.position = new Vector3(0, 4, -5);
        object1.GetComponent<Renderer>().material.color = Color.green;
        object1.AddComponent<Rigidbody>();

        destroytarget = GameObject.Find("object2");
        Destroy(destroytarget);
        GameObject object2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        object2.name = "object2";
        object2.transform.position = new Vector3(8, 4, -5);
        object2.GetComponent<Renderer>().material.color = Color.green;
        object2.AddComponent<Rigidbody>();
        maincamera.targetObject = object2;

        destroytarget = GameObject.Find("enemy1");
        Destroy(destroytarget);
        GameObject enemy1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy1.name = "enemy1";
        enemy1.GetComponent<Renderer>().material.color = Color.blue;
        enemy1.transform.position = new Vector3(0, 4, 3);
        enemy1.AddComponent<Rigidbody>();
        maincamera.enemy1= enemy1;

        destroytarget = GameObject.Find("enemy2");
        Destroy(destroytarget);
        GameObject enemy2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy2.name = "enemy2";
        enemy2.GetComponent<Renderer>().material.color = Color.blue;
        enemy2.transform.position = new Vector3(8, 4, 3);
        enemy2.AddComponent<Rigidbody>();
        maincamera.enemy2 = enemy2;

        Destroy(destroytarget);
    }
}
