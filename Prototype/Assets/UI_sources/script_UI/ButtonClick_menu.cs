using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick_menu: MonoBehaviour
{

    public void OnClick(int number)
    {

        switch (number)
		{

		case 0:
			SceneManager.LoadScene ("Chapter1");
			break;
		case 1:
//			Application.LoadLevel ("charaScene");
			break;

		case 2:
//			Application.LoadLevel ("pazzuleScene");
			break;

		case 3:
			break;
		default:
			break;
        }

    }
}
