using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField]
    float move_speed;
    [SerializeField]
    float Cam_sensitivity;
    [SerializeField]
    float Jump_power;
    [SerializeField]
    Transform Cam_transfrom;
    [SerializeField]
    int jump_count;
    [SerializeField]
    bool isground;
    [SerializeField]
    int MAXjump_count;// =2;
    [SerializeField]
    Vector3 reset=new Vector3(0,0,0);
    [SerializeField]
    float DS_SP;
    [SerializeField]
    Animator Anime;
    [SerializeField]
    bool testmood = false;
    [SerializeField]
    float PlayerHP;
    [SerializeField]
    float Max_PlayerHP;
    [SerializeField]
    Text HPtext;
    [SerializeField]
    Text Max_HPtext;
    [SerializeField]
    float KBP;
    bool KB_Flag;
    void Start()
    {
        KB_Flag = false;
        rb = GetComponent<Rigidbody>();
        //MAXjump_count = 2;
        reset = this.transform.position;
        Cam_transfrom.rotation = Quaternion.identity;
        Anime = GetComponent<Animator>();
        Max_HPtext.text = Max_PlayerHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (!testmood)
        {
            Cam_Controle();
        }
        
        Jump();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //マウスカーソルが表示
            Cursor.lockState = CursorLockMode.None;
        }
       
        //マウスが通常の時に、かつマウスをクリックすると
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            //マウスが消える
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            testmood = !testmood;
        }
        HPtext.text = PlayerHP.ToString();
       
    }
    

void Move()
    {
        float x = 0;
        float z = 0;
        if (Input.GetKey(KeyCode.W))
        {
            z = 1;
            Anime.SetBool("Walk",true);
        }
        else
        {
            Anime.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            z *= DS_SP;
            x *= DS_SP;
        }
        if (z > 1)
        {
            Anime.SetBool("Run", true);
        }
        else
        {
            Anime.SetBool("Run", false);
        }

        //Vector3 vec = new Vector3(x, 0, z) * move_speed;
        Vector3 vec = (transform.forward * z + transform.right * x)*move_speed;
        if (!KB_Flag)
        {
            //rb.velocity = new Vector3(vec.x, rb.velocity.y, vec.z);
        }
       
    }

    void Cam_Controle()
    {
        float mousex = Input.GetAxis("Mouse X") * Cam_sensitivity;
        float mousey = Input.GetAxis("Mouse Y") * Cam_sensitivity; 

        transform.rotation *= Quaternion.Euler(0, mousex, 0);
        if((Cam_transfrom.rotation*Quaternion.Euler(-mousey, 0, 0)).eulerAngles.x<60|| (Cam_transfrom.rotation * Quaternion.Euler(-mousey, 0, 0)).eulerAngles.x>300)
        {
            Cam_transfrom.rotation *= Quaternion.Euler(-mousey, 0,0 );
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&jump_count<MAXjump_count)
        {
            rb.AddForce(0, Jump_power , 0);
            jump_count += 1;
            Anime.SetBool("Jump",true);
           
        }
        else
        {
            Anime.SetBool("Jump",  false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        
        jump_count = 0;
        reset = transform.position;
        if (collision.transform.tag == "Enemy")
        {
            PlayerHP -= 10;
            rb.velocity = Vector3.zero;
            KBP = collision.gameObject.GetComponent<Enemy>().KBpower;
            Vector3 distination = (collision.transform.position - transform.position);
            Vector3 dis = new Vector3(distination.x, 0, distination.z).normalized * KBP;

            Debug.Log(distination);
            rb.AddForce(distination * KBP, ForceMode.VelocityChange);
        }
            /*if (collision.transform.tag == "Enemy")
            {
                PlayerHP -= 10;
                rb.velocity = Vector3.zero;
                Vector3 destination = (collision.transform.position - transform.position);
                KBP = collision.gameObject.GetComponent<Enemy>().KBpower;
                Vector3 dest = new Vector3(destination.x, 0, destination.z).normalized * KBP;
                Debug.Log(destination);
                rb.AddForce(destination*KBP, ForceMode.VelocityChange);
                KB_Flag = true;
                //rb.velocity = new Vector3(distination.x * KBP, 10, distination.z * KBP);
            }*/
        }
    private void Reset()
    {
        this.transform.position = reset;
        Cam_transfrom.localRotation = Quaternion.Euler(-77.01f, 101.3f, -10.666f);
    }

}
