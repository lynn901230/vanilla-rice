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
    private MainCamera _mainCamera;
//    private EnemyController _enemy_attack;
	private Vector3 _movement;
	public Vector3 target_pos;
	public Vector3 init_pos;
	private Vector3[] _path;
	public bool start_clicked = false;

    private void Start()
    {
        _mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
//        _enemy_attack = GameObject.Find("Enemy").GetComponent<EnemyController>();
    }
		
    public void OnClick()
	{
		//Debug.Log (init_pos);
		start_clicked = true;
//		Debug.Log (start_clicked);
        if (_mainCamera.button_flag == true)
        {
            _mainCamera.button_flag = false;
            foreach (Transform slotTransform in slots)
            {
                GameObject item = slotTransform.GetComponent<Slot>().item;
                if (item)
                {
                    namelist.Add(item.name);
					if (item.name == "50")
					{
						_movement += new Vector3(1, 0, 0);
					}//50の処理をするunity側のコードを記述 straight
					else if (item.name == "51")
					{
						_movement += new Vector3(0, 0, 0.75f);
					}//51の処理をするunity側のコードを記述 left
					else if (item.name == "52")
					{
						_movement += new Vector3(0, 0, -0.75f);
					}//52の処理をするunity側のコードを記述 right
                }
            }
			if (namelist.Count != 0) {
				target_pos = _movement + _mainCamera.desk.transform.position;
				_movement = new Vector3 (0, 0, 0);
				_mainCamera.Output ();
				namelist.Clear ();
			} 
        }
    }
}
