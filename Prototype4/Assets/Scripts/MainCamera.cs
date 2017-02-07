using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainCamera : MonoBehaviour {
    // Use this for initialization
    private ButtonClick buttonClick;
    private List<string> _namelist = new List<string>();
    public GameObject targetObject;
    public GameObject enemy2;
    private int j = 0, k = 0;
    int speed = 1;
    public GameObject desk;
    public string objectName = null;
    public string clickedObj;
    // rayが届く範囲
    public float distance = 10000f;

    public void Start () {
        buttonClick = GameObject.Find("StartButton").GetComponent<ButtonClick>();
        _namelist = buttonClick.namelist;
        //GameObject hero = GameObject.Find("self");

        //主人公カメラ視点設定
        transform.position = new Vector3(-5, 2.7f, 1);
        transform.rotation = Quaternion.Euler(20, 90, 0);

        enemy2 = GameObject.Find("Enemy");
        //enemy2.name = "enemy2";
        enemy2.AddComponent<Rigidbody>();
        enemy2.GetComponent<Rigidbody>().useGravity = false;
        enemy2.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool temp = EventSystem.current.IsPointerOverGameObject(); //マウスカーソルがuGUIにあるかどうか
        if (!temp)
        {
            // 左クリックを取得
            if (Input.GetMouseButtonDown(0))
            {
                // クリックしたスクリーン座標をrayに変換
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // Rayの当たったオブジェクトの情報を格納する
                RaycastHit hit = new RaycastHit();
                // オブジェクトにrayが当たった時
                if (Physics.Raycast(ray, out hit, distance) & hit.collider.gameObject.tag == "Object")
                {
                    // rayが当たったオブジェクトの名前を取得
                    objectName = hit.collider.gameObject.name;
                    clickedObj = hit.collider.gameObject.tag;
                    desk = GameObject.Find(objectName);
                    Debug.Log(clickedObj);
                }
                else
                {
                    clickedObj = hit.collider.gameObject.tag;
                    Debug.Log(clickedObj);
                    //clickedObj = LayerMask.LayerToName(hit.collider.gameObject.layer);
                    objectName = null;
                    desk = null;
                    //Debug.Log(desk);
                }
                targetObject = desk;
            }
        }
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
            targetObject.transform.position += new Vector3(1, 0, 0);
        }//50の処理をするunity側のコードを記述 straight
        else if (number == "51")
        {
            targetObject.transform.position += new Vector3(0, 0, 0.75f);
        }//51の処理をするunity側のコードを記述 left
        else if (number == "52")
        {
            targetObject.transform.position += new Vector3(0, 0, -0.75f);
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


}
