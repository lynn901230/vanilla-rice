using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToBattleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Onclick () {
        SceneManager.LoadScene("Classroom");
	}
}
