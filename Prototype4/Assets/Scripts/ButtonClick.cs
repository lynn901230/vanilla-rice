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
    private EnemyController _enemy_attack;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        _enemy_attack = GameObject.Find("Enemy").GetComponent<EnemyController>();
    }
    public void OnClick()
    {
        if (mainCamera.button_flag == true)
        {
            mainCamera.button_flag = false;
            foreach (Transform slotTransform in slots)
            {
                GameObject item = slotTransform.GetComponent<Slot>().item;
                if (item)
                {
                    namelist.Add(item.name);
                }
            }
            mainCamera.Output();
            StartCoroutine("DelayMethod",.5f);
            namelist.Clear();
        }
    }
    
    private IEnumerator DelayMethod(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _enemy_attack.Attack();
    }
}
