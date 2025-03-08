using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status_UI : MonoBehaviour
{
    [SerializeField]
    GameObject Status_HPtext;
    [SerializeField]
    GameObject Status_MAxamount_text;
    [SerializeField]
    GameObject Status_Speedtext;
    [SerializeField]
    float HP;
    [SerializeField]
    int Maxjunp_amount;
    [SerializeField]
    float Speed;
    // Start is called before the first frame update
    void OnEnable()
    {
        HP = PlayerPrefs.GetFloat("HP",100);
        Maxjunp_amount=PlayerPrefs.GetInt("Max_jump",2);
        Speed=PlayerPrefs.GetFloat("Speed",6);
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI HP_text = Status_HPtext.GetComponent<TextMeshProUGUI>();

        HP_text.text =HP.ToString();
        TextMeshProUGUI Max_junp_amount_text = Status_MAxamount_text.GetComponent<TextMeshProUGUI>();
        Max_junp_amount_text.text =Maxjunp_amount.ToString();
        TextMeshProUGUI Speed_text = Status_Speedtext.GetComponent<TextMeshProUGUI>();
        Speed_text.text =Speed.ToString("f1");
    }
}
