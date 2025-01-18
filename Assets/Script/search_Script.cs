using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class search_Script : MonoBehaviour
{
    [SerializeField]
    float search_angle;
    [SerializeField]
    Enemy2 enemy2;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "player")
        {
           
            Vector3 playerdirection = other.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, playerdirection);
           
            enemy2.MITUKETA = true;
            //StartCoroutine(enemy2.JumpForward());
            if (angle <= search_angle)
            {
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            enemy2.MITUKETA = false;
        }
    }
}
