using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_con : Base_comtroller
{
    [Header("ÉJÉÅÉâ")]   
    [SerializeField]
    Transform Camera_pos_1st;
    [SerializeField]
    Transform Cameta_pos_3rd;
    [SerializeField]
    float Camera_pos_rate=0; 
    int scroll_step = 1;
    [SerializeField]
    public bool Shopping;
    
    protected override void Start()
    {
        base.Start();
        Shopping = false;
        Optioning = false;
       
        rb = GetComponent<Rigidbody>();
        Cam_transfrom.rotation = Quaternion.identity;
        Anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
       
        
        
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            
            if (Shopping == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        





    }
    protected override void Cam_Controle()
    {
        
        if (Shopping == false)
        {
            base.Cam_Controle();
        }
    }
    protected override void Move()
    {
        if (Shopping == false)
        {
            base.Move();
        }
        
    }
    protected override void open_option()
    {
        if (Shopping == false)
        {
            base.open_option();
        }

    }
}
