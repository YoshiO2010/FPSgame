using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Shop_BuyScript : MonoBehaviour
{
    [SerializeField]
    string key_name;
    [SerializeField]
    float Up_amout;
    [SerializeField]
    int Powerint;
    [SerializeField]
    float Powerfloat;
    [SerializeField]
    int powerup_cost;
    [SerializeField]
    GameObject PowerUpname_Object;
    [SerializeField]
    GameObject PowerUpcost_Object;
    [SerializeField]
    GameObject PowerUpamount_Object;
    [SerializeField]

    public enum type
    {
        Int,Float,Bool
    }
    [SerializeField]
    type Type = type.Float;
    // Start is called before the first frame update
    void OnEnable()
    {
        Powerint= PlayerPrefs.GetInt(key_name, 0);
        Powerfloat = PlayerPrefs.GetFloat(key_name, 0);

    }
    public void Up_Glade_Buy()
    {
        int money_num = PlayerPrefs.GetInt("MONEY", 0);
        if (money_num >= powerup_cost)
        {
            if (Type == type.Float)
            {
                Powerfloat += Up_amout;
                PlayerPrefs.SetFloat(key_name, Powerfloat);
               
            }
            else
            {
                Powerint +=(int) Up_amout;
                PlayerPrefs.SetInt(key_name, Powerint);
               
            }
            PlayerPrefs.SetInt("MONEY", money_num - powerup_cost);
            PlayerPrefs.Save();
        }
        
       
        
    }
    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI Name_text = PowerUpname_Object.GetComponent<TextMeshProUGUI>();
        Name_text.text = key_name.ToString();
        TextMeshProUGUI amount_text = PowerUpamount_Object.GetComponent<TextMeshProUGUI>();
        amount_text.text = Up_amout.ToString();
        TextMeshProUGUI Cost_text = PowerUpcost_Object.GetComponent<TextMeshProUGUI>();
        Cost_text.text = powerup_cost.ToString();
    }
}
