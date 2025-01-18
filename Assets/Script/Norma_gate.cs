using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Norma_gate : MonoBehaviour
{
    Gamemode_mane GMM;
    // Start is called before the first frame update
    void Start()
    {
        GMM = GameObject.FindWithTag("Game_mane").GetComponent<Gamemode_mane>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.CompareTag("player"))
        {
            GMM.setgamemode(1);
            SceneManager.LoadScene("Gamescene");
        }
    }
}
