using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : Base_comtroller
{
    [Header("HP")]
    [SerializeField]
    Vector3 reset=new Vector3(0,0,0);
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
    [Header("ノックバック")]
    [SerializeField]
    float KBP;
    public bool KB_Flag;
    bool invincible;
    [SerializeField]
    float invincible_time;
    [Header("END")]
    public GameObject END;
    bool Gameover_Flag;
    [SerializeField]
    AudioSource audiosource;
    [SerializeField]
    AudioClip DameseSE;
    protected override void Start()
    {
        base.Start();
        Gameover_Flag = false;
        invincible = false;
        KB_Flag = false;
        Max_PlayerHP = 100;
        Max_PlayerHP += PlayerPrefs.GetFloat("HP", 0);
        PlayerHP = Max_PlayerHP;
        reset = this.transform.position;
        Max_HPtext.text = Max_PlayerHP.ToString();
        END.SetActive(false);

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            testmood = !testmood;
        }
        HPtext.text = PlayerHP.ToString();
        if (PlayerHP <= 0&&Gameover_Flag==false)
        {
            Gameover_Flag = true;
            Cursor.lockState = CursorLockMode.None;
            END.SetActive(true);
            GameObject.FindWithTag("GameController").GetComponent<Score>().resultMoney();
            //GetComponent<player_controller>().enabled = false;
        }
      
    }
    


  

    
    protected override void OnCollisionEnter(Collision collision)
    {
        
        Enemy enemy_script = collision.gameObject.GetComponent<Enemy>();
        if (collision.transform.CompareTag("Enemy")&& invincible==false&& enemy_script != null)
        {
            invincible = true;
            StartCoroutine(MUTEKI_time());
            PlayerHP -= enemy_script.Attack_power;
            StartCoroutine(Knockbacktime());
            DameseSEPlay();
            // ノックバック処理
            Vector3 Direction = (transform.position - collision.transform.position);
            Direction.y = 0;
            Direction = Direction.normalized;
            Vector3 knockbackDirection = new Vector3(Direction.x,0.2f, Direction.z).normalized;
            
            float knockbackPower;
            knockbackPower = enemy_script.KBpower;
            rb.velocity = Vector3.zero; // 現在の速度をリセット
            rb.AddForce(knockbackDirection * knockbackPower, ForceMode.VelocityChange);
            
        }


     

        // リセット位置の更新
        reset = transform.position;
        // ジャンプカウントのリセット
        jump_count = 0;
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
    public IEnumerator MUTEKI_time()
    {
        yield return new WaitForSeconds(invincible_time);
        invincible = false;
    }
    public void DameseSEPlay()
    {
        audiosource.PlayOneShot(DameseSE);
    }
}
