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
    public void start_button() //change_button�Ƃ������O�ɂ��܂�
    {
        SceneManager.LoadScene("Gamescene");//second���Ăяo���܂�
    }
    public void change_button() //change_button�Ƃ������O�ɂ��܂�
    {
        SceneManager.LoadScene("Title");//second���Ăяo���܂�
    }

}
