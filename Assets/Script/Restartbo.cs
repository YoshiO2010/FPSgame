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
    public void start_button() //change_buttonという名前にします
    {
        SceneManager.LoadScene("Gamescene");//secondを呼び出します
    }
    public void change_button() //change_buttonという名前にします
    {
        SceneManager.LoadScene("Title");//secondを呼び出します
    }

}
