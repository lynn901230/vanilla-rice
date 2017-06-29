using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour {
    // Use this for initialization
    private ButtonClick _buttonClick;
    private List<string> _namelist = new List<string>();
    public GameObject targetObject;
    public GameObject enemy2;
    public bool button_flag; //ボタン押しのフラグ
    private int j = 0, k = 0;
    int speed = 1;
    public GameObject desk;
    public string objectName = null;
    public string clickedObj;
    public float time_cnt = 0;//オブジェクト移動時間のカウント
    // rayが届く範囲
    public float distance = 100f;
	public float width = 0;
	public float depth = 0;
	public Vector3 ObjtargetPos; //目標位置
	public Vector3 StartPos; //スタート位置
	bool testflag = false;

    public void Start () {
        Debug.Log(SceneManager.GetActiveScene().name);
        _buttonClick = GameObject.Find("StartButton").GetComponent<ButtonClick>();
        _namelist = _buttonClick.namelist;
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
        bool temp = EventSystem.current.IsPointerOverGameObject(); //マウスカーソルがuGUIにあるかどうか（パネル状態でオブジェクト選択を回避するため）
        if (!temp)
        {
            // 左クリックを取得
            if (Input.GetMouseButtonDown(0))
            {
				testflag = true;
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
                    button_flag = true;//オブジェクトを選択してからstartボタンが実行可能
                }
                else
                {
                    clickedObj = hit.collider.gameObject.tag;
					//Debug.Log (clickedObj);
                    //clickedObj = LayerMask.LayerToName(hit.collider.gameObject.layer);
                    objectName = null;
                    desk = null;
                    //Debug.Log(desk);
                }
                targetObject = desk;
				StartPos = targetObject.transform.position;
				ObjtargetPos = StartPos;
				Debug.Log (targetObject.name + " startpos: " + StartPos);
//				Vector3 test_pos = new Vector3 (targetObject.transform.position.x + 1,
//					                   targetObject.transform.position.y + 1,
//					                   targetObject.transform.position.z + 1);
//				Debug.Log (test_pos);
            }
        }
		if (testflag == true && targetObject.transform.position == ObjtargetPos) {
			Debug.Log ("same" + ObjtargetPos);
			testflag = false;
		}
    }

    //出力処理
    public void Output()
    {
		
		if (constructCode (_namelist)) {
			//testflag = true;
			//Debug.Log ("OK!!!");
		} else {
			Debug.Log ("NG!!!");
		}
        time_cnt = 0;
//		depth = 0; //位置判定パラメータx初期化
//		width = 0; //位置判定パラメータz初期化
    }

    //単独処理
    public IEnumerator function(string number)
	{
		if (number == "50")//50の処理をするunity側のコードを記述 straight
        {
            targetObject.transform.position += new Vector3(1, 0, 0);
            time_cnt++;			//depth++;
			ObjtargetPos.x +=1f;
        }
		else if (number == "51")//51の処理をするunity側のコードを記述 left
        {
            targetObject.transform.position += new Vector3(0, 0, 0.75f);
            time_cnt++;
			ObjtargetPos.z +=0.75f;
			//width++;
        }
		else if (number == "52")//52の処理をするunity側のコードを記述 right
        {
            targetObject.transform.position += new Vector3(0, 0, -0.75f);
            time_cnt++;
			ObjtargetPos.z -=0.75f;
			//width--;
        }
		yield return new WaitForSeconds(speed / 10f * j + k / 2f);//           Debug.Log(speed / 5f * (j + 1) * (k + 1));
		testflag = true;
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
//		ObjtargetPos = new Vector3 (StartPos.x + depth * 1f, 
//			StartPos.y, 
//			StartPos.z + width * 0.75f);
        return true;
    }


}
