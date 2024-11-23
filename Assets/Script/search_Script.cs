using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class search_Script : MonoBehaviour
{
    [SerializeField]
    float search_angle;
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
        if (other.tag == "Player")
        {
            Vector3 playerdirection = other.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, playerdirection);
            if (angle <= search_angle)
            {
                Debug.Log("MITUKETA");
            }
        }
    }
}
