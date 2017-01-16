using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainCamera : MonoBehaviour {
    // Use this for initialization
    //private List<GameObject> myList = new List<GameObject>();
    private ButtonClick buttonClick;
    private List<string> _namelist = new List<string>();
    public GameObject targetObject;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject object1;
    public GameObject object2;
    private int j = 0, k = 0;
    int speed = 1;
    public GameObject chair;
    public GameObject desk;
    public void Start () {
        buttonClick = GameObject.Find("StartButton").GetComponent<ButtonClick>();
        chair = Instantiate(Resources.Load("Prefabs/Chair", typeof(GameObject))) as GameObject;
        //desk = Instantiate(Resources.Load("Prefabs/Desk", typeof(GameObject))) as GameObject;
        _namelist = buttonClick.namelist;
        //transform.position = new Vector3(5, 10, -10);
        //transform.Rotate(new Vector3(50, 0.5f, 0));
        //int xPos = -6;
        //int i = 0;
        //// Z位置を+1しながらマップを生成していく
        //for (; xPos < 7; xPos++)
        //{
        //    int zPos = -4;
        //    for (; zPos < 5; zPos++)
        //    {
        //        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //        myList.Add(cube);
        //        myList[i].transform.position = new Vector3(xPos, 0, zPos);
        //        if (i % 2 != 1)
        //        {
        //            myList[i].GetComponent<Renderer>().material.color = Color.black;
        //        }
        //        i++;
        //    }
        //}
        GameObject hero = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        hero.transform.position = new Vector3(0, 1.5f, -4);
        hero.GetComponent<Renderer>().material.color = Color.red;

        enemy1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy1.name = "enemy1";
        enemy1.GetComponent<Renderer>().material.color = Color.blue;
        enemy1.transform.position = new Vector3(-4, 1.5f, 4);
        enemy1.AddComponent<Rigidbody>();

        enemy2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        enemy2.name = "enemy2";
        enemy2.GetComponent<Renderer>().material.color = Color.blue;
        enemy2.transform.position = new Vector3(4, 1.5f, 4);
        enemy2.AddComponent<Rigidbody>();

        chair.transform.position = new Vector3(-4, 1.5f, -4);
        chair.name = "object1";
        chair.AddComponent<Rigidbody>();
        chair.AddComponent<BoxCollider>();

        //desk.transform.position = new Vector3(4, 1, -4);
        //desk.name = "object2";
        //desk.AddComponent<Rigidbody>();
        //desk.AddComponent<BoxCollider>();
        desk = GameObject.Find("desk01");
        //desk = GameObject.Find("desk02");
        desk.AddComponent<Rigidbody>();
        desk.AddComponent<BoxCollider>();

        //Rigidbody test;
        //test = GameObject.Find("object2").GetComponent<Rigidbody>();
        //test.mass = 100;
        targetObject = desk;
    }
    //出力処理
    public void Output()
    {
        if (constructCode(_namelist)) Debug.Log("OK!!!");
        else Debug.Log("NG!!!");
    }

    //単独処理
    public IEnumerator function(string number)
    {
        yield return new WaitForSeconds(speed / 10f * j + k / 2f);//           Debug.Log(speed / 5f * (j + 1) * (k + 1));
        if (number == "50")
        {
            targetObject.transform.position += new Vector3(0, 0, 1);
        }//50の処理をするunity側のコードを記述 straight
        else if (number == "51")
        {
            targetObject.transform.position += new Vector3(-1, 0, 0);
        }//51の処理をするunity側のコードを記述 left
        else if (number == "52")
        {
            targetObject.transform.position += new Vector3(1, 0, 0);
        }//52の処理をするunity側のコードを記述 right
    }

    //for文処理
    public void functionFor(string loop, List<string> numbers)
    {
        for (k=1; k < int.Parse(loop)+1; k++)
        {
            for (j = 0; j < numbers.Count; j++)
            {
                StartCoroutine(function(numbers[j]));
            }
        }
    }

    //構文解釈
    public bool constructCode(List<string> code)
    {
        bool forFlag = false;
        List<string> numbers = new List<string>();
        
        //構文エラー処理
        for (int i = 0; i < code.Count; i++)
        {
            if (code[i].Substring(0, 1) == "4") break;
            else if (code[i] == "end") return false;
        }

        //構文解釈処理
        string loop = "0";
        for (int i = 0; i < code.Count; i++)
        {
            if (code[i].Substring(0,1) == "4")
            {
                forFlag = true;
                loop = code[i].Substring(1, 1);
            }
            else if (code[i] == "end")
            {
                if(numbers.Count != 0) functionFor(loop, numbers);
                forFlag = false;
            }
            else if (forFlag)
            {
                numbers.Add(code[i]);
            }
            else
            {
                if (k == 0)
                {
                    StartCoroutine(function(code[i]));
                    k++;
                }
                else
                {
                    j--;
                    StartCoroutine(function(code[i]));
                    j += 2;
                }
            }
        }
        j = 0;
        k = 0;
        return true;
    }

    // Update is called once per frame
    void Update () {
    }
}
