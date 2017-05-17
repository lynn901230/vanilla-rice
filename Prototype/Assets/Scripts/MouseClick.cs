using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour
{
    public string objectName = null;
    // rayが届く範囲
    public float distance = 100f;
    void Update()
    {
        bool temp = EventSystem.current.IsPointerOverGameObject();
        Debug.Log(temp);
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
                }
                else
                {
                    objectName = null;
                }
                Debug.Log(objectName);
            }
        }
    }
}
