using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showpanel : MonoBehaviour
{
    GameObject player_obj;
    [SerializeField]
    GameObject keypanel;
    [SerializeField]
    float Show_Dist;
    [SerializeField]
    KeyCode Interact_Key;
    [SerializeField]
    string Interact_str;
    [SerializeField]
    TextMeshProUGUI Interact_text;
    [SerializeField]
    GameObject Shop_panel;

    // Start is called before the first frame update
    void Start()
    {
        Shop_panel.SetActive(false);
        player_obj= GameObject.FindWithTag("player");
        keypanel.SetActive(false);
        Interact_text.text = Interact_str;
    }

    // Update is called once per frame
    void Update()
    {
        float Dist = (transform.position - player_obj.transform.position).magnitude;
        if (Dist < Show_Dist)
        {
            keypanel.SetActive(true);
            if (Input.GetKeyDown(Interact_Key))
            {
                player_obj.GetComponent<Title_con>().Shopping = true;
                Shop_panel.SetActive(true);
                Debug.Log("Shop");
                //マウスカーソルが表示
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            keypanel.SetActive(false);
        }
   }
}
