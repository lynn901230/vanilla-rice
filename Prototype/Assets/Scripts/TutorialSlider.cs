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
    private EnemyController _enemy;
    public int clickCnt = 0;
    public Text tutorial_text;
    public Image downArrow;
	public int arrow_flag = 0;// {1:"obj",2:"startbt",3:"codebt"};
	string[] text_array = { "コードでの戦い方について説明するよ","まず、動かす机を選ぶよ。", "この机を選ぼう。",
        "これは「coding」ボタン", "一回押すとコーディングパネルが召喚され",
        "もう一回押すとパネルが帰還する","さあ、冒険を始めよう" };
    // Use this for initialization
    void Start () {
        tutorial_text = GameObject.Find("Tutorial_Text").GetComponent<Text>();
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
        if (clickCnt == text_array.Length)
        {
            StartCoroutine(TSlider(false));
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
        tutorial_text.text = text_array[clickCnt];
        if(clickCnt == 3)
        {            
//            downArrow.transform.localPosition = new Vector3(-330,-150,0);
			StartCoroutine(TSlider(false));
			arrow_flag = 1;
        }
        if (clickCnt == 4)
        {
            //downArrow.transform.localPosition = new Vector3(-220, -150, 0);
        }
//        if (clickCnt == 4)
//        {
//            downArrow.transform.localPosition = new Vector3(-110, -150, 0);
//        }
//        if (clickCnt == 7)
//        {
//            downArrow.transform.localPosition = new Vector3(-500, -150, 0);
//        }        
    }
}
