using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WLSlider : MonoBehaviour {
    public AnimationCurve wl_animeCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public float wl_duration = 1.0f;    // スライド時間（秒）
    public Vector3 wl_inPosition;      // スライドイン後の位置
    private EnemyController _enemy;
    // Use this for initialization
    void Start () {
        _enemy = GameObject.Find("Enemy").GetComponent<EnemyController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_enemy.enemyhp <= 0)
        {
            StartCoroutine(WinSlider());
        }
	}

    public IEnumerator WinSlider()
    {
        float startTime = Time.time;    // 開始時間
        Vector3 startPos = transform.localPosition;  // 開始位置
        Vector3 moveDistance;
        moveDistance = (wl_inPosition - startPos);
        while ((Time.time - startTime) < wl_duration)
        {
            transform.localPosition = startPos + moveDistance * wl_animeCurve.Evaluate((Time.time - startTime) / wl_duration);
            yield return 0;        // 1フレーム、再開
        }
        transform.localPosition = startPos + moveDistance;
    }

}
