using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Novel;

public class ButtonClick_Cp_1_1 : MonoBehaviour
{

    public void OnClick(int number)
    {

		switch (number) {

		case 0:
			SceneManager.LoadScene ("menu");
			break;
		case 1:
			NovelSingleton.StatusManager.callJoker("wide/scene1","");
			break;
		case 2:
			NovelSingleton.StatusManager.callJoker("wide/scene2","");
			break;
		case 3:
			SceneManager.LoadScene ("Classroom_q1");
			break;
		case 4:
			NovelSingleton.StatusManager.callJoker("wide/scene3","");
			break;
		case 5:
			SceneManager.LoadScene ("Classroom_q2");
			break;
		case 6:
			NovelSingleton.StatusManager.callJoker("wide/scene4","");
			break;
		case 7:
			SceneManager.LoadScene ("Classroom_q1");
			break;
		default:
			break;
		}
    }
}
