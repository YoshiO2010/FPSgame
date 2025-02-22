using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_BuyScript : MonoBehaviour
{
    [SerializeField]
    string key_name;
    [SerializeField]
    int Up_amout;
    [SerializeField]
    int Powerint;
    [SerializeField]
    float Powerfloat;
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
        if (Type == type.Float)
        {
            Powerfloat += Up_amout;
            PlayerPrefs.SetFloat(key_name, Powerfloat);
            PlayerPrefs.Save();
        }
        else
        {
            Powerint += Up_amout;
            PlayerPrefs.SetInt(key_name, Powerint);
            PlayerPrefs.Save();
        }
       
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
