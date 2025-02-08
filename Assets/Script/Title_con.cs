using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_con : MonoBehaviour
{
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
    Vector3 reset = new Vector3(0, 0, 0);
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
    float KBP;
    public bool KB_Flag;
    bool invincible;
    [SerializeField]
    float invincible_time;
    [SerializeField]
    public GameObject Option_UI;
    public bool Optioning;
    [SerializeField]
    Transform Camera_pos_1st;
    [SerializeField]
    Transform Cameta_pos_3rd;
    [SerializeField]
    float Camera_pos_rate=0; 
    int scroll_step = 1;
    public bool Shopping;
    [SerializeField]
    GameObject status_UI;
    bool Open_Inventory;
    void Start()
    {
        Shopping = false;
        Optioning = false;
        invincible = false;
        KB_Flag = false;
        rb = GetComponent<Rigidbody>();
        //MAXjump_count = 2;
        reset = this.transform.position;
        Cam_transfrom.rotation = Quaternion.identity;
        Anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Optioning = !Optioning;
            Option_UI.SetActive(Optioning);
            Time.timeScale = 0;
            //マウスカーソルが表示
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Open_Inventory = !Open_Inventory;
            status_UI.SetActive(Open_Inventory);
            Time.timeScale = 0;
            //マウスカーソルが表示
            Cursor.lockState = CursorLockMode.None;
        }
        if (!testmood)
        {
            if (Optioning == false&& Shopping==false)
            {
                if (z > 1)
                {
                    Anime.SetBool("Run", true);
                }
                else
                {
                    Anime.SetBool("Run", false);
                }
                float mousex = Input.GetAxis("Mouse X") * Cam_sensitivity;
                float mousey = Input.GetAxis("Mouse Y") * Cam_sensitivity;

                // プレイヤーの回転を Rigidbody 経由で行う
                Quaternion deltaRotation = Quaternion.Euler(0, mousex, 0);
                rb.MoveRotation(rb.rotation * deltaRotation);

                // カメラの回転を制限付きで調整
                float newRotationX = Cam_transfrom.localEulerAngles.x - mousey;
                if (newRotationX > 180) newRotationX -= 360; // 回転角度を -180 ~ 180 に制限
                newRotationX = Mathf.Clamp(newRotationX, -45, 45);
                //カメラの場所を調整
                if (Input.mouseScrollDelta.y < 0)
                {
                    scroll_step = 4;
                }
                else if (Input.mouseScrollDelta.y > 0)
                {
                    scroll_step = -4;
                }
                Camera_pos_rate += Time.deltaTime * scroll_step;
                Camera_pos_rate = Mathf.Clamp(Camera_pos_rate, 0, 1);
                Vector3 Camera_pos = Vector3.Lerp(Camera_pos_1st.position, Cameta_pos_3rd.position, Camera_pos_rate);
                Cam_transfrom.position = Camera_pos;


                Cam_transfrom.localEulerAngles = new Vector3(newRotationX, 0, 0);
                Vector3 vec = (transform.forward * z + transform.right * x) * move_speed;
                rb.velocity = new Vector3(vec.x, rb.velocity.y, vec.z);
            }
            
        }

        

        //マウスが通常の時に、かつマウスをクリックすると
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            if (!Shopping)
            {
                //マウスが消える
                Cursor.lockState = CursorLockMode.Locked;
            }
           
        }
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
    private void OnCollisionEnter(Collision collision)
    {
        // ジャンプカウントのリセット
        jump_count = 0;
    }
}
