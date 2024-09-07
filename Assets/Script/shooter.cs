using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct GunData
{
    public Gun_detaCreate DG;
    public Transform startpoint;
    public Animator Gun_animator;
}

public class shooter : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet_prefabe;
    [SerializeField]
    Transform cameratransform;
    float ct_time;
    int magazine;
    [SerializeField]
    Text magazine_Text;
    [SerializeField]
    Text Max_magazine_Text;
    bool relod;
    float relod_ct;
    [SerializeField]
    Image[] relod_mada;
    [SerializeField]
    Image[] relod_zumi;
    [SerializeField]
    int Gun_Num;
    [SerializeField]
    GunData[] gundata;
    float take_ct;
    bool take;
    [SerializeField]
    Animator Gun_animator;
    [SerializeField]
    Animator Gun_animator2;
    [SerializeField]
    GameObject MF;
    [SerializeField]
    GameObject MFPB;


    void Start()
    {
        take = false;
        take_ct = 0f;
        ct_time = 0f;
        magazine = gundata[Gun_Num].DG.Max_magazine; //Max_magazine;
        relod = false;
        relod_ct = 0f;
        for (int i = 0; relod_mada.Length > i; i++)
        {
            relod_mada[i].gameObject.SetActive(false);
        }
        for (int i = 0; relod_zumi.Length > i; i++)
        {
            relod_zumi[i].gameObject.SetActive(false);
        }
        Max_magazine_Text.text = gundata[Gun_Num].DG.Max_magazine.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ct_time += Time.deltaTime;
        if (Input.GetMouseButton(0)&&relod==false&&take==false)
        {
            if (ct_time >= gundata[Gun_Num].DG.ct && magazine > 0)
            {


                for (float i = 0; i < gundata[Gun_Num].DG.pellet; i++)
                {
                    Debug.Log("”­ŽË");
                    GameObject Bullet = Instantiate(Bullet_prefabe);

                    Bullet.transform.position = gundata[Gun_Num].startpoint.position;
                    Vector3 shotvec = cameratransform.forward;
                    shotvec.x += Random.Range(-gundata[Gun_Num].DG.diffusion, gundata[Gun_Num].DG.diffusion) / 100;
                    shotvec.y += Random.Range(-gundata[Gun_Num].DG.diffusion, gundata[Gun_Num].DG.diffusion) / 100;
                    Bullet.transform.rotation = Quaternion.LookRotation(shotvec);
                    Vector3 vec = shotvec * gundata[Gun_Num].DG.Shootpower;
                    Bullet.GetComponent<Rigidbody>().AddForce(vec);
                    Destroy(Bullet, 5f);
                }
                ct_time = 0f;
                magazine -= 1;
            }
            if (MFPB != null)
            {
                if (MF != null)
                {
                    MF.SetActive(true);
                }
                else
                {
                   
                    MF = Instantiate(MFPB, gundata[Gun_Num].startpoint);
                    MF.transform.SetParent(gundata[Gun_Num].startpoint);
                    MF.transform.localScale = gundata[Gun_Num].DG.MFsize;
                }
            }
           
           
        }
        else
        {
            if (MF != null)
            {
                MF.SetActive(false);
                MF = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; relod_mada.Length > i; i++)
            {
                relod_mada[i].gameObject.SetActive(true);
            }
                relod = true;
            relod_ct = Time.time + gundata[Gun_Num].DG.relod_time;
            //relod_mada.gameObject.SetActive(true);
        }
        
        for (int i = 0; relod_zumi.Length > i; i++)
        {
            if (relod_ct - gundata[Gun_Num].DG.relod_time * (relod_zumi.Length - i) / relod_zumi.Length < Time.time && relod == true)
            {
                relod_zumi[i].gameObject.SetActive(true);
            }
            
        }
        if (relod_ct < Time.time&&relod==true)
        {
           // relod_mada.gameObject.SetActive(false);
            magazine = gundata[Gun_Num].DG.Max_magazine;
            relod = false;
            for (int i = 0; relod_mada.Length > i; i++)
            {
                relod_mada[i].gameObject.SetActive(false);
            }
            for (int i = 0; relod_zumi.Length > i; i++)
            {
                relod_zumi[i].gameObject.SetActive(false);
            }
        }
        //relod_mada.value = (Time.time - relod_ct+relod_time) / relod_time
        Changegun();
        if (take_ct < Time.time&&take==true) 
        {
            
            if (gundata.Length <= Gun_Num)
            {
                Gun_Num = 0;
            }
            magazine = gundata[Gun_Num].DG.Max_magazine;
            take = false;
            Max_magazine_Text.text =  gundata[Gun_Num].DG.Max_magazine.ToString();
            for (int i = 0; i < gundata.Length; i++)
            {
                if (i == Gun_Num)
                {
                    gundata[i].DG.Gun_Object.SetActive(true);
                }
                else
                {
                    gundata[i].DG.Gun_Object.SetActive(false);
                }
            }
        }
        magazine_Text.text = magazine.ToString() ;
        if (Input.GetMouseButtonDown(1))
        {
            gundata[Gun_Num].Gun_animator.SetTrigger("AIM");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            //gundata[Gun_Num].Gun_animator.SetTrigger("BACK AIM");
        }
        /*if (Gun_Num == 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Gun_animator.SetTrigger("AIM");
            }
            else if (Input.GetMouseButtonUp(1))
            {
                Gun_animator.SetTrigger("BACK AIM");
            }
        }*/
       
        
    }
    public int Getgundamage() 
    {

        return gundata[Gun_Num].DG.Damage;
    }
    void Changegun()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            take = true;
            take_ct = Time.time + gundata[Gun_Num].DG.taka_time;
            Gun_Num++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            take = true;
            take_ct = Time.time + gundata[0].DG.taka_time;
            Gun_Num = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            take = true;
            take_ct = Time.time + gundata[1].DG.taka_time;
            Gun_Num = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            take = true;
            take_ct = Time.time + gundata[2].DG.taka_time;
            Gun_Num = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            take = true;
            take_ct = Time.time + gundata[3].DG.taka_time;
            Gun_Num = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            take = true;
            take_ct = Time.time + gundata[4].DG.taka_time;
            Gun_Num = 4;
        }
    }
}
