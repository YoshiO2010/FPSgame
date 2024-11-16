using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    GameObject scoreObject;
    [SerializeField]
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text text=scoreObject.GetComponent<Text>();
        text.text = score.ToString();

    }
    public void Plusscore(int point)
    {
        score += point;
    }
}
