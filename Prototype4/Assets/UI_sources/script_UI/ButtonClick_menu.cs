using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClick_menu: MonoBehaviour
{

    public void OnClick(int number)
    {

        switch (number)
        {

            case 0:
                Application.LoadLevel("Chapter1");
                break;
            case 1:
                Application.LoadLevel("Charactor");
                break;

            case 2:
                Application.LoadLevel("pazzuleScene");
                break;

            default:
                break;
        }

    }
}
