using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PanelSlider : MonoBehaviour
{
    public AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public Vector3 inPosition;        // スライドイン後の位置
    public Vector3 outPosition;      // スライドアウト後の位置
    public float duration = 1.0f;    // スライド時間（秒）
    public int clickcnt = 0;
	private TutorialSlider _TS;
	public bool button_clicked = false;

	void Start(){
		if (SceneManager.GetActiveScene ().name == "Classroom_q1") {
			_TS = GameObject.Find ("Tutorial").GetComponent<TutorialSlider> ();
		}
	}

    // スライドイン
    public void Slider()
    {
		if (SceneManager.GetActiveScene ().name == "Classroom_q1") {
			if (_TS.Button_flag == true) {
				clickcnt++;
				button_clicked = true;
				if (clickcnt % 2 == 1) {
					StartCoroutine (StartSlidePanel (true));
				}
        // スライドアウト
       			else {
					StartCoroutine (StartSlidePanel (false));
				}
			}
		} else {
			clickcnt++;
			button_clicked = true;
			if (clickcnt % 2 == 1) {
				StartCoroutine (StartSlidePanel (true));
			}
			// スライドアウト
			else {
				StartCoroutine (StartSlidePanel (false));
			}
		}
    }

    private IEnumerator StartSlidePanel(bool isSlideIn)
    {
        float startTime = Time.time;    // 開始時間
        Vector3 startPos = transform.localPosition;  // 開始位置
        Vector3 moveDistance;            // 移動距離および方向

        if (isSlideIn)
            moveDistance = (inPosition - startPos);
        else
        {
            moveDistance = (outPosition - startPos);
        }
        while ((Time.time - startTime) < duration)
        {
            transform.localPosition = startPos + moveDistance * animCurve.Evaluate((Time.time - startTime) / duration);
            yield return 0;        // 1フレーム後、再開
        }
        transform.localPosition = startPos + moveDistance;
    }
}
