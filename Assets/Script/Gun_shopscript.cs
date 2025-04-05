using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Gun_tipe
{
    AR,
    MLG,
    SG,
    SR,

}

public class Gun_shopscript : MonoBehaviour
{
    [SerializeField]
    GameObject Shootpowar_textnum;
    [SerializeField]
    GameObject Gun_rate_textnum;
    [SerializeField]
    GameObject MAX_Magazine_num;
    [SerializeField]
    GameObject Reload_time_num;
    [SerializeField]
    GameObject Take_time_num;
    [SerializeField]
    GameObject Damage_text_num;
    [SerializeField]
    GameObject Pellet_num;
    public float Shootpower;
    public float ct;
    public int Max_magazine;
    public float relod_time;
    public float take_time;
    public int Damage;
    public int pellet;
    public float Shootpower_puls;
    public float ct_puls;
    public int Max_magazine_puls;
    public float relod_time_puls;
    public float take_time_puls;
    public int Damage_puls;
    public int pellet_puls;
    public float Shootpower_amount;
    public float ct_amount;
    public int Max_magazine_amount;
    public float relod_time_amount;
    public float take_time_amount;
    public int Damage_amount;
   
    [SerializeField]
    Gun_detaCreate gundata;
    public Gun_tipe ET;
    string tipe_name;
    int money_num;
    
    // Start is called before the first frame update
    void Start()
    {
        money_num = PlayerPrefs.GetInt("MONEY", 500);

       
        Shootpower = gundata.Shootpower;
        ct = gundata.ct;
        Max_magazine = gundata.Max_magazine;
        relod_time = gundata.relod_time;
        take_time = gundata.taka_time;
        Damage = gundata.Damage;
        pellet = gundata.pellet;
        switch (ET)
        {
            case Gun_tipe.AR:
                tipe_name = "AR";

                break;
            case Gun_tipe.MLG:
                tipe_name = "LMG";
                
                break;
            case Gun_tipe.SG:
                tipe_name = "SG";
                
                break;
            case Gun_tipe.SR:
                tipe_name = "SR";
               
                break;
        }
        Shootpower_puls = PlayerPrefs.GetFloat(tipe_name + "Shootpower_puls", 0);
        ct_puls = PlayerPrefs.GetFloat(tipe_name + "ct_puls", 0);
        Max_magazine_puls = PlayerPrefs.GetInt(tipe_name + "Max_magazine_puls", 0);
        relod_time_puls = PlayerPrefs.GetFloat(tipe_name + "relod_time_puls", 0);
        take_time_puls = PlayerPrefs.GetFloat(tipe_name + "take_time_puls", 0);
        Damage_puls = PlayerPrefs.GetInt(tipe_name + "Damage_puls", 0);
        pellet_puls = PlayerPrefs.GetInt(tipe_name + "pellet_puls", 0);


    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI Shootpower_text = Shootpowar_textnum.GetComponent<TextMeshProUGUI>();
        Shootpower_text.text = Shootpower.ToString()+" (+"+Shootpower_amount*Shootpower_puls+")";
        TextMeshProUGUI Ct_text = Gun_rate_textnum.GetComponent<TextMeshProUGUI>();
        Ct_text.text = ct.ToString() + " (+" + ct_amount*ct_puls + ")";
        TextMeshProUGUI Max_magazine_text = MAX_Magazine_num.GetComponent<TextMeshProUGUI>();
        Max_magazine_text.text = Max_magazine.ToString() + " (+" + Max_magazine_amount*Max_magazine_puls + ")";
        TextMeshProUGUI relod_time_text = Reload_time_num.GetComponent<TextMeshProUGUI>();
        relod_time_text.text = relod_time.ToString() + " (+" + relod_time_amount*relod_time_puls + ")";
        TextMeshProUGUI take_time_text = Take_time_num.GetComponent<TextMeshProUGUI>();
        take_time_text.text = take_time.ToString() + " (+" + take_time_amount*take_time_puls + ")";
        TextMeshProUGUI Damage_text = Damage_text_num.GetComponent<TextMeshProUGUI>();
        Damage_text.text = Damage.ToString() + " (+" + Damage_amount*Damage_puls + ")";
        TextMeshProUGUI pellet_text = Pellet_num.GetComponent<TextMeshProUGUI>();
        pellet_text.text = pellet.ToString() + " (+" + pellet_puls + ")";
        
    }
    public void Gun_status_Buy(string key_name)
    {
        float power_UP_amount=1;
        int power_UP_cost=100;
        money_num = PlayerPrefs.GetInt("MONEY", 500);
        if (money_num >= power_UP_cost)
        {
            switch (key_name)
            {
                case "Shootpower":
                    Shootpower_puls += power_UP_amount;
                    PlayerPrefs.SetFloat(tipe_name + key_name + "_puls", Shootpower_puls);
                    break;
                case "Gunrate":
                    {
                        ct_puls += power_UP_amount;
                        PlayerPrefs.SetFloat(tipe_name + key_name + "_puls", ct_puls);
                    }
                    break;
                case "Max_magazine":
                    {
                        Max_magazine_puls += (int)power_UP_amount;
                        PlayerPrefs.SetInt(tipe_name + key_name + "_puls", Max_magazine_puls);
                    }
                    break;
                case "relod_time":
                    {
                        relod_time_puls += power_UP_amount;
                        PlayerPrefs.SetFloat(tipe_name + key_name + "_puls", relod_time_puls);
                    }
                    break;
                case "take_time":
                    {
                        take_time_puls += power_UP_amount;
                        PlayerPrefs.SetFloat(tipe_name + key_name + "_puls", take_time_puls);
                    }
                    break;
                case "Damage":
                    {
                        Damage_puls += (int)power_UP_amount;
                        PlayerPrefs.SetInt(tipe_name + key_name + "_puls", Damage_puls);
                    }
                    break;
            }
            money_num -= power_UP_cost;
            PlayerPrefs.SetInt("MONEY", money_num);
            PlayerPrefs.Save();
        }
       
    }
}
