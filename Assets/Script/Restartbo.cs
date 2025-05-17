using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restartbo : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void start_button() 
    {
        SceneManager.LoadScene("Gamescene");
    }
    public void Return_Title_button()
    {
        SceneManager.LoadScene("Title");
    }
    public void Return_Option()
    {
        
    }
    public void return_to_base()
    {
        GameObject.FindWithTag("GameController").GetComponent<Score>().resultMoney();
        SceneManager.LoadScene("Title");
    }
}
