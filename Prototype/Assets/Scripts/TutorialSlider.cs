using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialSlider : MonoBehaviour {
    public AnimationCurve t_animeCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float t_duration = 1.0f;    // スライド時間（秒）
    public Vector3 t_inPosition;      // スライドイン後の位置
    public Vector3 t_outPosition;      //スライドアウト後の位置
//    private EnemyController _enemy;
	public MainCamera MCforTS;
	public bool Button_flag = false; //ボタン押しフラグ
    public int clickCnt = 0;
    public Text tutorial_text;
    public Image downArrow;
	public PanelSlider PS;
	private bool _cps_flag;
	private ButtonClick _start_btn;
	private EnemyController _enemy_ctrl;

	public int TS_flag = 0;//チュートリアル進行フラグ
	// {0:"out",1:"obj",2:"startbt",3:"codebt",4:"you win"};
	string[] text_array = { "コードでの戦い方について説明するよ", "まず、動かす机を選ぶよ。", "この机を選ぼう。",
		"次に机の動き方をプログラミングするよ。", "Codeボタンを押そう。",
		"obj.frontで前、obj.rightで右、\nobj.leftで左に動くよ。", "obj.rightとobj.frontを選んで\n下のパネルに持ってこよう。",
		"できたら、もう一度Codeボタンを押そう。", "スタートで攻撃できるよ","その調子！頑張って！","勝ったわ！おめでとう！"
	};//length 9
    // Use this for initialization
    void Start () {
		if(SceneManager.GetActiveScene ().name != "Classroom_q1"){
			Button_flag = true;
		}
		MCforTS = GameObject.Find ("Main Camera").GetComponent<MainCamera> ();
        tutorial_text = GameObject.Find("Tutorial_Text").GetComponent<Text>();
		PS = GameObject.Find ("CodingPanel").GetComponent<PanelSlider>();
		_start_btn = GameObject.Find ("StartButton").GetComponent<ButtonClick> ();
		_enemy_ctrl = GameObject.Find ("Enemy").GetComponent<EnemyController>();
        tutorial_text.text = text_array[clickCnt];
        downArrow = GameObject.Find("Down_Arrow").GetComponent<Image>();
        if (SceneManager.GetActiveScene().name == "Classroom_q1")
        {
            StartCoroutine(TSlider(true));
        }
        //downArrow = Instantiate(Resources.Load("Prefabs/Down_Arrow", typeof(Image))) as Image;
    }
	
	// Update is called once per frame
	void Update () {
		if (_enemy_ctrl.enemyhp <= 0 & clickCnt != 12) {
			StartCoroutine (TSlider (true));

		}
		switch(TS_flag){
		case 0:
			downArrow.transform.localPosition = new Vector3 (-400, -400, 0);
			break;
		case 1:
			downArrow.transform.localPosition = new Vector3 (-40, 85, 0);
			if (MCforTS.targetObject.transform.name == "obj2_q1") {
				TS_flag = 0;
				StartCoroutine (TSlider (true));
			}
			break;
		case 2:
			downArrow.transform.localPosition = new Vector3 (-330, -180, 0);
			if (_start_btn.start_clicked == true & MCforTS.targetObject == null) {
				TS_flag = 0;
				StartCoroutine (TSlider (true));
			}
			break;
		case 3			:
			downArrow.transform.localPosition = new Vector3 (-220, -180, 0);
			Button_flag = true;
			if (PS.button_clicked == true) {
				PS.button_clicked = false;
				StartCoroutine (TSlider (true));
				Button_flag = false;
				TS_flag = 0;
			}
			break;
		}
	}

    public IEnumerator TSlider(bool slideFlag)
    {
        float startTime = Time.time;    // 開始時間
        Vector3 startPos = transform.localPosition;  // 開始位置
        Vector3 moveDistance;
        if (slideFlag)
        {
            moveDistance = (t_inPosition - startPos);
        }
        else
        {
            moveDistance = (t_outPosition - startPos);
        }
        while ((Time.time - startTime) < t_duration)
        {
            transform.localPosition = startPos + moveDistance * t_animeCurve.Evaluate((Time.time - startTime) / t_duration);
            yield return 0;        // 1フレーム、再開
        }
        transform.localPosition = startPos + moveDistance;
    }

    public void OnClick()
    {
		clickCnt++;
		Debug.Log (clickCnt);
		if (clickCnt == 12) {
			SceneManager.LoadScene("Chapter1");
		}
		tutorial_text.text = text_array[clickCnt-1];
        if(clickCnt == 4)
        {            
			StartCoroutine(TSlider(false));
			TS_flag = 1;
        }
        if (clickCnt == 6)
        {
			StartCoroutine(TSlider(false));
			TS_flag = 3;
        }
        if (clickCnt == 9)
        {
			StartCoroutine(TSlider(false));
			TS_flag = 3;
        }
		if (clickCnt == 10)
        {
			StartCoroutine(TSlider(false));
			TS_flag = 2;
        }
		if (clickCnt == 11) {
			StartCoroutine(TSlider(false));
			TS_flag = 0;
			Button_flag = true;
		}
//		if (clickCnt == 12) {
//			StartCoroutine(TSlider(false));
//		}
//		tutorial_text.text = text_array[clickCnt-1];
    }
}
