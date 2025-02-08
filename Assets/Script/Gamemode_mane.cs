using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Gamemode
{
    easy,
    normal,
    hard,

}
public class Gamemode_mane : MonoBehaviour
{
   
    public Gamemode gamemode;
    public static Gamemode_mane GMode;
    // Start is called before the first frame update
    void Start()
    {
        if (Gamemode_mane.GMode==null)
        {
            GMode = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setgamemode(Gamemode gamemode_index)
    {
        gamemode = gamemode_index;
    }
}
