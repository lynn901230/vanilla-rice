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
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if (item)
            {
                namelist.Add(item.name);
            }
        }
        mainCamera.Output();
        namelist.Clear();
    }
  
}
