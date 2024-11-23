using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class search_Script : MonoBehaviour
{
    [SerializeField]
    float search_angle;
    public bool found_flag;
    // Start is called before the first frame update
    void Start()
    {
        found_flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "player")
        {
            Debug.Log("TIKAI");
            Vector3 playerdirection = other.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, playerdirection);
            if (angle <= search_angle)
            {
                Debug.Log("MITUKETA");
                found_flag = true;
            }
        }
    }
}
