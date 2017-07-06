using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick_Chara : MonoBehaviour {

	public void OnClick(int number)
	{

		switch (number)
		{

		case 0:
			Application.LoadLevel("menu");
			break;
		default:
			break;
		}

	}
}
