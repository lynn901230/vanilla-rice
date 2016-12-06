using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonClick : MonoBehaviour{

    [SerializeField]
    Transform slots;
    [SerializeField]
    Text inventoryText;
    public List<string> namelist = new List<string>();
    private MainCamera mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
    }
    public void OnClick()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if (item)
            {
                builder.Append(item.name);
                builder.Append("\n");
                namelist.Add(item.name);
            }
        }
        //inventoryText.text = builder.ToString();//画面にコードリスト表示
        mainCamera.Output();
        namelist.Clear();
    }
  
}
