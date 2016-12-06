using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BattleSystem : MonoBehaviour {

    int speed = 1;
    public GameObject targetObject;
    private int j = 0, k = 0;
    //単独処理
    public IEnumerator function(string number)
    {
        yield return new WaitForSeconds(speed / 5f * j + k / 2f);//           Debug.Log(speed / 5f * (j + 1) * (k + 1));
        Debug.Log(speed / 5f * j + k / 2f);
        if (number == "50")
        {
            targetObject.transform.position += new Vector3(0, 0, 1);
        }//50の処理をするunity側のコードを記述 straight
        else if (number == "51")
        {
            targetObject.transform.position += new Vector3(-1, 0, 0);
        }//51の処理をするunity側のコードを記述 left
        else if (number == "52")
        {
            targetObject.transform.position += new Vector3(1, 0, 0);
        }//52の処理をするunity側のコードを記述 right
    }

    //for文処理
    public void functionFor(string loop, List<string> numbers)
    {
        for (k = 1; k < int.Parse(loop) + 1; k++)
        {
            for (j = 0; j < numbers.Count; j++)
            {
                StartCoroutine(function(numbers[j]));
            }
        }
    }

    //構文解釈
    public bool constructCode(List<string> code)
    {
        bool forFlag = false;
        List<string> numbers = new List<string>();

        //構文エラー処理
        for (int i = 0; i < code.Count; i++)
        {
            if (code[i].Substring(0, 1) == "4") break;
            else if (code[i] == "end") return false;
        }

        //構文解釈処理
        string loop = "0";
        for (int i = 0; i < code.Count; i++)
        {
            if (code[i].Substring(0, 1) == "4")
            {
                forFlag = true;
                loop = code[i].Substring(1, 1);
            }
            else if (code[i] == "end")
            {
                if (numbers.Count != 0) functionFor(loop, numbers);
                forFlag = false;
            }
            else if (forFlag)
            {
                numbers.Add(code[i]);
            }
            else
            {
                if (k == 0)
                {
                    StartCoroutine(function(code[i]));
                    k++;
                }
                else
                {
                    j--;
                    StartCoroutine(function(code[i]));
                    j += 2;
                }
            }
        }
        j = 0;
        k = 0;
        return true;
    }
}
