using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop_sctipt : MonoBehaviour
{
    [SerializeField]
    GameObject money_Object;
    int money_num;
    [SerializeField]
    GameObject Gun_Shop_panel;
    [SerializeField]
    GameObject AR_statuspanel;

    // Start is called before the first frame update
    void Start()
    {
        money_num = PlayerPrefs.GetInt("MONEY", 0);
        AR_statuspanel.SetActive(false);
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("MONEY", money_num);
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Close_shoppanel();
        }
        TextMeshProUGUI money_text = money_Object.GetComponent<TextMeshProUGUI>();

        money_text.text = "Money"+money_num;
        
    }
    void Close_shoppanel()
    {
        GameObject.FindWithTag("player").GetComponent<Title_con>().Shopping=false;
        gameObject.SetActive(false);

    }
    public void Open_Gunpanel()
    {
        gameObject.SetActive(false);
        Gun_Shop_panel.SetActive(true);
    }
    public void Close_panel()
    {
        Gun_Shop_panel.SetActive(false);
        GameObject.FindWithTag("player").GetComponent<Title_con>().Shopping = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Display_ARstatus()
    {
        AR_statuspanel.SetActive(true);
    }
}
