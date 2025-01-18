using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode_mane : MonoBehaviour
{
    public enum Gamemode
    {
        easy,
        normal,
        hard,

    }
    public Gamemode gamemode;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setgamemode(int gamemode_index)
    {
        gamemode =(Gamemode) gamemode_index;
    }
}
