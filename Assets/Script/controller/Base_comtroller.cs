using System.Collections;
using UnityEngine;

public class Base_comtroller : MonoBehaviour
{
    protected Rigidbody rb;

    [Header("移動")]
    [SerializeField]
    protected float move_speed;
    [SerializeField]
    protected float DS_SP;
    [SerializeField]
    protected float Jump_power;
    [SerializeField]
    protected int jump_count;
    [SerializeField]
    protected bool isground;
    [SerializeField]
    protected int MAXjump_count;// =2;
    [Header("カメラ")]
    [SerializeField]
    protected float Cam_sensitivity;
    [SerializeField]
    protected Transform Cam_transfrom;
    [Header("アニメ")]
    [SerializeField]
    protected Animator Anime;
    [SerializeField]
    protected GameObject Option_UI;
    [SerializeField]
    protected bool Optioning;
    [SerializeField]
    protected GameObject status_UI;
    [SerializeField]
    bool Open_Inventory;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        MAXjump_count = 2;
        MAXjump_count += PlayerPrefs.GetInt("Max_jump", 0);
        move_speed = 6;
        move_speed += PlayerPrefs.GetFloat("Speed", 0); 
        Cam_transfrom.rotation = Quaternion.identity;
        Anime = GetComponent<Animator>();
        Optioning = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        
        Jump();
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            open_option();
        }
        if (Optioning == false)
        {
            Cam_Controle();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Open_Inventory = !Open_Inventory;
            status_UI.SetActive(Open_Inventory);
            if (Optioning == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            //マウスカーソルが表示
            Cursor.lockState = CursorLockMode.None;
        }





    }
    protected virtual void open_option()
    {
        Optioning = !Optioning;
        Option_UI.SetActive(Optioning);
        if (Optioning == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        //マウスカーソルが表示
        Cursor.lockState = CursorLockMode.None;
    }
    protected virtual void Move()
    {
        float x = 0;
        float z = 0;
        if (Input.GetKey(KeyCode.W))
        {
            z = 1;
            Anime.SetBool("Walk", true);
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
        Vector3 vec = (transform.forward * z + transform.right * x) * move_speed;
        rb.velocity = new Vector3(vec.x, rb.velocity.y, vec.z);

    }

    protected virtual void Cam_Controle()
    {
        float mousex = Input.GetAxis("Mouse X") * Cam_sensitivity;
        float mousey = Input.GetAxis("Mouse Y") * Cam_sensitivity;

        // プレイヤーの回転を Rigidbody 経由で行う
        Quaternion deltaRotation = Quaternion.Euler(0, mousex, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // カメラの回転を制限付きで調整
        float newRotationX = Cam_transfrom.localEulerAngles.x - mousey;
        if (newRotationX > 180) newRotationX -= 360; // 回転角度を -180 ~ 180 に制限
        newRotationX = Mathf.Clamp(newRotationX, -60, 60);

        Cam_transfrom.localEulerAngles = new Vector3(newRotationX, 0, 0);


    }

    protected virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump_count < MAXjump_count)
        {
            rb.AddForce(0, Jump_power, 0);
            jump_count += 1;
            Anime.SetBool("Jump", true);

        }
        else
        {
            Anime.SetBool("Jump", false);
        }
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        // ジャンプカウントのリセット
        jump_count = 0;
    }
    
}


