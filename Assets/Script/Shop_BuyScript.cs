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
    int Power;
    // Start is called before the first frame update
    void Start()
    {
        Power= PlayerPrefs.GetInt(key_name, 0);
         
    }
    void Up_Glade_Buy()
    {
        Power += Up_amout;
        PlayerPrefs.SetInt(key_name, Power);
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
