using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Titlebottan : MonoBehaviour
{
    [SerializeField]
    GameObject Titlepanel;
    [SerializeField]
    Text start_text;
    [SerializeField]
    float Blinking_interval = 1;
    Color Def_color;
    float A_point;
    float point_variation;

    // Start is called before the first frame update
    void Start()
    {
        Titlepanel.SetActive(true);
        Def_color = start_text.color;
        A_point = 1;
        point_variation = -1 / Blinking_interval * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Titlepanel.SetActive(false);
        }
        A_point += Time.deltaTime * point_variation;
        if (A_point <= 0&&point_variation<0)
        {
            point_variation *= -1;
            
        }
        if (A_point >= 1 && point_variation > 0)
        {
            point_variation *= -1;
        }
        start_text.color = new Color(Def_color.r, Def_color.g, Def_color.b, A_point);
        
    }
}
