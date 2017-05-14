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
    string[] text_array = { "ようこそ、コードの世界へ","チュートリアルを進めるには「OK」を押してください", "これは「start」ボタン",
        "これは「reset」ボタン", "これは「coding」ボタン", "一回押すとコーディングパネルが召喚され",
        "もう一回押すとパネルが帰還する","さあ、冒険を始めよう" };
    // Use this for initialization
    void Start () {
        tutorial_text = GameObject.Find("Tutorial_Text").GetComponent<Text>();
        tutorial_text.text = text_array[clickCnt];
        downArrow = GameObject.Find("Down_Arrow").GetComponent<Image>();
        if (SceneManager.GetActiveScene().name == "Classroom1")
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
        if(clickCnt == 2)
        {            
            //downArrow.transform.SetParent(transform,true);
            downArrow.transform.localPosition = new Vector3(-330,-200,0);
        }
        if (clickCnt == 3)
        {
            downArrow.transform.localPosition = new Vector3(-220, -200, 0);
        }
        if (clickCnt == 4)
        {
            downArrow.transform.localPosition = new Vector3(-110, -200, 0);
        }
        if (clickCnt == 7)
        {
            downArrow.transform.localPosition = new Vector3(-500, -200, 0);
        }        
    }
}
