using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick_Cp_1_1 : MonoBehaviour
{

    public void OnClick(int number)
    {

		switch (number) {

		case 0:
			SceneManager.LoadScene ("menu");
			break;
		case 1:
			SceneManager.LoadScene ("Player");
			break;
		case 2:
			SceneManager.LoadScene ("Classroom_q1");
			break;
		default:
			break;
		}
    }
}
