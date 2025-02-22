using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    GameObject Damese_textnum;
    [SerializeField]
    GameObject Pellet_num;
    public float Shootpower;
    public float ct;
    public int Max_magazine;
    public float relod_time;
    public float taka_time;
    public int Damage;
    public int pellet;
    [SerializeField]
    GunData[] gundata;
    // Start is called before the first frame update
    void Start()
    {
        Shootpower = PlayerPrefs.GetFloat("Shootpower", 600);
        ct = PlayerPrefs.GetFloat("ct", 0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI Shootpower_text = Shootpowar_textnum.GetComponent<TextMeshProUGUI>();
        Shootpower_text.text = Shootpower.ToString();
        TextMeshProUGUI Ct_text = Gun_rate_textnum.GetComponent<TextMeshProUGUI>();
        Ct_text.text = ct.ToString();
    }
}
