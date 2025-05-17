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
    [SerializeField]
    GameObject MLG_statuspanel;
    [SerializeField]
    GameObject SG_statuspanel;
    [SerializeField]
    GameObject SR_statuspanel;
    [SerializeField]
    GameObject Gunshop_moneyObj;
    [SerializeField]
    GameObject Shop_panel_file;

    // Start is called before the first frame update
    void Start()
    {
        money_num = PlayerPrefs.GetInt("MONEY", 500);
        PlayerPrefs.SetInt("MONEY", money_num);
        PlayerPrefs.Save();
        AR_statuspanel.SetActive(false);
        MLG_statuspanel.SetActive(false);
        SG_statuspanel.SetActive(false);
        SR_statuspanel.SetActive(false);

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
            Close_panel();
        }
        TextMeshProUGUI money_text = money_Object.GetComponent<TextMeshProUGUI>();
        money_num = PlayerPrefs.GetInt("MONEY", 500);
        Debug.Log(money_num);
        money_text.text = "Money"+money_num;
        TextMeshProUGUI Money_text = Gunshop_moneyObj.GetComponent<TextMeshProUGUI>();
        Money_text.text = "MONEY:\n" + money_num;
    }
    /*void Close_shoppanel()
    {
        GameObject.FindWithTag("player").GetComponent<Title_con>().Shopping=false;
        gameObject.SetActive(false);

    }*/
    public void Open_Gunpanel()
    {
        Shop_panel_file.SetActive(false);
        Gun_Shop_panel.SetActive(true);
        Gunshop_moneyObj.SetActive(true);
        //TextMeshProUGUI Money_text = Gunshop_moneyObj.GetComponent<TextMeshProUGUI>();
        //Money_text.text = "MONEY:\n" + money_num;
    }
    public void Close_panel()
    {
        gameObject.SetActive(false);
        Gun_Shop_panel.SetActive(false);
        GameObject.FindWithTag("player").GetComponent<Title_con>().Shopping = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Display_ARstatus()
    {
        SG_statuspanel.SetActive(false);
        SR_statuspanel.SetActive(false);
        MLG_statuspanel.SetActive(false);
        AR_statuspanel.SetActive(true);
    }
    public void Display_MLGstatus()
    {
        SG_statuspanel.SetActive(false);
        SR_statuspanel.SetActive(false);
        MLG_statuspanel.SetActive(true);
        AR_statuspanel.SetActive(false);
    }
    public void Display_Sgstatus()
    {
        SR_statuspanel.SetActive(false);
        AR_statuspanel.SetActive(false);
        MLG_statuspanel.SetActive(false);
        SG_statuspanel.SetActive(true);
    }
    public void Display_SRstatus()
    {
        AR_statuspanel.SetActive(false);
        MLG_statuspanel.SetActive(false);
        SG_statuspanel.SetActive(false);
        SR_statuspanel.SetActive(true);
    }
}
