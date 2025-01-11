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
    public bool KB_Flag;
    public GameObject END;
    void Start()
    {
        END.SetActive(false);
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
        if (PlayerHP == 0)
        {
            END.SetActive(true);
        }
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
        if (KB_Flag == false)
        {
            rb.velocity = new Vector3(vec.x, rb.velocity.y, vec.z);
        }
        
       
    }

    void Cam_Controle()
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

        //transform.rotation *= Quaternion.Euler(0, mousex, 0);
        //if((Cam_transfrom.rotation*Quaternion.Euler(-mousey, 0, 0)).eulerAngles.x<60|| (Cam_transfrom.rotation * Quaternion.Euler(-mousey, 0, 0)).eulerAngles.x>300)
        //{
        //    Cam_transfrom.rotation *= Quaternion.Euler(-mousey, 0,0 );
        //}
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
        Debug.Log(collision.transform.tag);

        if (collision.transform.CompareTag("Enemy"))
        {
            PlayerHP -= 10;
            StartCoroutine(Knockbacktime());
            // ノックバック処理
            Vector3 Direction = (transform.position - collision.transform.position);
            Direction.y = 0;
            Direction = Direction.normalized;
            Vector3 knockbackDirection = new Vector3(Direction.x,0.3f, Direction.z).normalized;
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            float knockbackPower;
            if (enemy != null)
            {
                knockbackPower = collision.gameObject.GetComponent<Enemy>().KBpower;
            }
            else
            {
                knockbackPower = collision.gameObject.GetComponent<Enemy2>().KBpower;
            }

            rb.velocity = Vector3.zero; // 現在の速度をリセット
            rb.AddForce(knockbackDirection * knockbackPower, ForceMode.VelocityChange);
            
        }

        // ジャンプカウントのリセット
        jump_count = 0;

        // リセット位置の更新
        reset = transform.position;
    }

    private void Reset()
    {
        this.transform.position = reset;
        Cam_transfrom.localRotation = Quaternion.Euler(-77.01f, 101.3f, -10.666f);
    }
    public IEnumerator Knockbacktime()
    {
        KB_Flag = true;
        yield return new WaitForSeconds(1f);
        KB_Flag = false;
    }

}
