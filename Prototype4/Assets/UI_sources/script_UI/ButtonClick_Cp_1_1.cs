﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClick_Cp_1_1 : MonoBehaviour
{

    public void OnClick(int number)
    {

        switch (number)
        {

            case 0:
                Application.LoadLevel("test");
                break;
            case 1:
                Application.LoadLevel("charaScene");
                break;

            case 2:
                Application.LoadLevel("pazzuleScene");
                break;
            default:
                break;
        }

    }
}