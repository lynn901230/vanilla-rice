using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;


public class Reset : MonoBehaviour
{
    private MainCamera _mainCamera;

    public void OnClick()
    {
		//using UnityEditor;を記述しておけば、最初のUnityEditorは省略可
		//引数はタイトル,メッセージ,OKボタンのテキスト,Cancelボタンのテキスト
		//OKボタンのみ
//		UnityEditor.EditorUtility.DisplayDialog("Notice", "Hello!", "OK");
		//Cancelボタンあり、OKかCancelかで処理分けする場合
		bool b = UnityEditor.EditorUtility.DisplayDialog("Warning!!", "本当にリセットしますか？", "はい", "いいえ");
		if (b) {
			_mainCamera = GameObject.Find ("Main Camera").GetComponent<MainCamera> ();
			GameObject destroytarget;

			destroytarget = GameObject.Find ("object1");
			Destroy (destroytarget);
			GameObject desk = Instantiate (Resources.Load ("Prefabs/desk02-test", typeof(GameObject))) as GameObject;
			desk.transform.position = new Vector3 (0, 0, 0);
			desk.name = "object1";
			desk.AddComponent<Rigidbody> ();
			desk.AddComponent<BoxCollider> ();
			_mainCamera.targetObject = desk;

			destroytarget = GameObject.Find ("enemy");
			Destroy (destroytarget);
			GameObject enemy = Instantiate (Resources.Load ("Prefabs/enemy", typeof(GameObject))) as GameObject;
			enemy.name = "enemy";
			//enemy.AddComponent<BoxCollider>();
			enemy.AddComponent<Rigidbody> ();
			enemy.GetComponent<Rigidbody> ().useGravity = false;
			enemy.GetComponent<Rigidbody> ().isKinematic = true;
			_mainCamera.enemy = enemy;
		}
    }
}
