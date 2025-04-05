using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    GameObject scoreObject;
    [SerializeField]
    GameObject resultscore;
    [SerializeField]
    int score;
    Gamemode_mane Level;
    // Start is called before the first frame update
    void Start()
    {
        Level = GameObject.FindWithTag("Game_mane").GetComponent<Gamemode_mane>();
    }

    // Update is called once per frame
    void Update()
    {
        Text text=scoreObject.GetComponent<Text>();
        text.text = score.ToString();
        Text R_text = resultscore.GetComponent<Text>();
        R_text.text = score.ToString();
    }
    public void Plusscore(int point)
    {
        score += point;
    }
    public void resultMoney()
    {
        int Money = PlayerPrefs.GetInt("MONEY", 0);
        Money += score * 100*(1+(int)Level.gamemode);
        PlayerPrefs.SetInt("MONEY", Money);
        PlayerPrefs.Save();
    }
}
