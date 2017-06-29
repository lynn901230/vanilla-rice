using UnityEngine;
using System.Collections;

public class timetest : MonoBehaviour
{
	private int _i = 0;
	private bool _flag = true;
	private int _k;

	// Use this for initialization
	void Start ()
	{
		for (_k = 0; _k <= 10; _k++) {
			StartCoroutine (Test ());
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private IEnumerator Test(){
		if (_flag == true) {
			Debug.Log (_i);
			_flag = false;
		}
		yield return new WaitForSeconds (3f);
		_i++;
		Debug.Log ("_i++");
		_flag = true;
	}
}

