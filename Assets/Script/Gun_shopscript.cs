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
    [SerializeField]
    GunData[] gundata;
    public Gun_tipe ET;
    // Start is called before the first frame update
    void Start()
    {
        switch (ET)
        {
            case Gun_tipe.AR:
                 Shootpower = PlayerPrefs.GetFloat("Shootpower", 600);
                 //Shootpower_puls = PlayerPrefs.GetFloat("Shootpower_puls", 0);
                 //Shootpower += Shootpower_puls;
                 ct = PlayerPrefs.GetFloat("ct", 0.08f);
                 Max_magazine = PlayerPrefs.GetInt("Max_magazine", 30);
                 relod_time = PlayerPrefs.GetFloat("relod_time", 0.6f);
                 take_time = PlayerPrefs.GetFloat("take_time", 1);
                 Damage = PlayerPrefs.GetInt("Damage", 2);
                 pellet = PlayerPrefs.GetInt("pellet", 1);
                break;
            case Gun_tipe.MLG:
                Shootpower = PlayerPrefs.GetFloat("Shootpower", 600);
                ct = PlayerPrefs.GetFloat("ct", 0.05f);
                Max_magazine = PlayerPrefs.GetInt("Max_magazine", 100);
                relod_time = PlayerPrefs.GetFloat("relod_time", 3);
                take_time = PlayerPrefs.GetFloat("take_time", 1.5f);
                Damage = PlayerPrefs.GetInt("Damage", 1);
                pellet = PlayerPrefs.GetInt("pellet", 1);
                break;
            case Gun_tipe.SG:
                Shootpower = PlayerPrefs.GetFloat("Shootpower", 500);
                ct = PlayerPrefs.GetFloat("ct", 0.4f);
                Max_magazine = PlayerPrefs.GetInt("Max_magazine", 8);
                relod_time = PlayerPrefs.GetFloat("relod_time", 0.6f);
                take_time = PlayerPrefs.GetFloat("take_time", 0.5f);
                Damage = PlayerPrefs.GetInt("Damage", 1);
                pellet = PlayerPrefs.GetInt("pellet", 5);
                break;
            case Gun_tipe.SR:
                Shootpower = PlayerPrefs.GetFloat("Shootpower", 1000);
                ct = PlayerPrefs.GetFloat("ct", 0.6f);
                Max_magazine = PlayerPrefs.GetInt("Max_magazine", 5);
                relod_time = PlayerPrefs.GetFloat("relod_time", 1);
                take_time = PlayerPrefs.GetFloat("take_time", 1.3f);
                Damage = PlayerPrefs.GetInt("Damage", 5);
                pellet = PlayerPrefs.GetInt("pellet", 1);
                break;
        }
            
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI Shootpower_text = Shootpowar_textnum.GetComponent<TextMeshProUGUI>();
        Shootpower_text.text = Shootpower.ToString();
        TextMeshProUGUI Ct_text = Gun_rate_textnum.GetComponent<TextMeshProUGUI>();
        Ct_text.text = ct.ToString();
        TextMeshProUGUI Max_magazine_text = MAX_Magazine_num.GetComponent<TextMeshProUGUI>();
        Max_magazine_text.text = Max_magazine.ToString();
        TextMeshProUGUI relod_time_text = Reload_time_num.GetComponent<TextMeshProUGUI>();
        relod_time_text.text = relod_time.ToString();
        TextMeshProUGUI take_time_text = Take_time_num.GetComponent<TextMeshProUGUI>();
        take_time_text.text = take_time.ToString();
        TextMeshProUGUI Damage_text = Damage_text_num.GetComponent<TextMeshProUGUI>();
        Damage_text.text = Damage.ToString();
        TextMeshProUGUI pellet_text = Pellet_num.GetComponent<TextMeshProUGUI>();
        pellet_text.text = pellet.ToString();
    }
    public void Gun_status_Buy(string key_name)
    {
        float power_UP_amount=1;
        switch (key_name)
        {
            case "Shootpower":
                Shootpower_puls += power_UP_amount;
                PlayerPrefs.SetFloat(key_name, Shootpower_puls);
                break;
            case "Gunrate":
                {
                    ct_puls -= power_UP_amount;
                    PlayerPrefs.SetFloat(key_name, ct_puls);
                }
                break;
            case "Max_magazine":
                {
                    Max_magazine_puls += (int)power_UP_amount;
                    PlayerPrefs.SetInt(key_name, Max_magazine_puls);
                }
                break;
            case "relod_time":
                {
                    relod_time_puls -= power_UP_amount;
                    PlayerPrefs.SetFloat(key_name, relod_time_puls);
                }
                break;
            case "take_time":
                {
                    take_time_puls -= power_UP_amount;
                    PlayerPrefs.SetFloat(key_name, take_time_puls);
                }
                break;
            case "Damage":
                {
                    Damage_puls += (int)power_UP_amount;
                    PlayerPrefs.SetInt(key_name, Damage_puls);
                }
                break;
        }
        PlayerPrefs.Save();
    }
}
