using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum Enemy_tipe
{
    Drone,
    Warrior,
}

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public shooter gun;
    [SerializeField]
    int MaxHP = 5;
    [SerializeField]
    int HP;
    [SerializeField]
    public float KBpower;
    public Enemy_tipe ET;
    [SerializeField]
    search_Script search;
    Rigidbody rb;
    public Transform[] points;
    int destpoint;
    [SerializeField]
    Transform parent;
    public bool MITUKETA;
    [SerializeField]
    float speed;
    GameObject Gamemanager;
    EnemyGeneraeor EG;
    Score score;
    public int Attack_power;
    [SerializeField]
    AudioSource audiosource;
    [SerializeField]
    AudioClip killenemy;
    bool Isdead;
    
    NavMeshAgent Agent;
    
    Transform player;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Buliet"))
        {
            HP-=gun.Getgundamage();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("player")&&ET==Enemy_tipe.Drone)
        {
            // NavMeshAgentを一時停止
            Agent.isStopped = true;

            //アニメーション入れるならここに


            // NavMeshAgentを再開
            StartCoroutine(ResumeNavMesh());
        }
    }
    void Start()
    {
        Isdead = false;
        switch (ET)
        {
            case Enemy_tipe.Drone:
                gun = FindObjectOfType<shooter>();
                Gamemanager = GameObject.FindWithTag("GameController");
                score = Gamemanager.GetComponent<Score>();
                EG = Gamemanager.GetComponent<EnemyGeneraeor>();
                player = GameObject.FindWithTag("player").transform;
                Agent = GetComponent<NavMeshAgent>();
                Agent.SetDestination(player.position);
                break;
            case Enemy_tipe.Warrior:
                MITUKETA = false;
                rb = GetComponent<Rigidbody>();
                gun = FindObjectOfType<shooter>();
                Gamemanager = GameObject.FindWithTag("GameController");
                score = Gamemanager.GetComponent<Score>();
                EG = Gamemanager.GetComponent<EnemyGeneraeor>();
                player = GameObject.FindWithTag("player").transform;
                Agent = GetComponent<NavMeshAgent>();
                //Agent.SetDestination(player.position);
                search = transform.GetChild(0).gameObject.GetComponent<search_Script>();

                destpoint = 0;
                parent = GameObject.Find("JUNKAI ").transform;
                points = new Transform[parent.childCount];
                for (int i = 0; i < parent.childCount; i++)
                {
                    points[i] = parent.GetChild(i);
                }
                goto_nextpoint();
                StartCoroutine(JumpForward());
                break;
            default:
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (ET)
        {
            case Enemy_tipe.Drone:
                if (HP <= 0&&Isdead==false)
                {
                    StartCoroutine(EnemyKill());

                }
                if (Agent.pathStatus != NavMeshPathStatus.PathInvalid)
                {
                    Agent.SetDestination(player.position);
                }
                break;
            case Enemy_tipe.Warrior:
                if (HP <= 0 && Isdead == false)
                {
                    StartCoroutine(EnemyKill());
                    

                }


                // transform.position = new Vector3(transform.position.x+speed, transform.position.y, transform.position.z+speed);
                if (!Agent.pathPending && Agent.pathStatus != NavMeshPathStatus.PathInvalid && Agent.remainingDistance < 0.5f)
                {
                    goto_nextpoint();
                }
                if (MITUKETA)
                {
                    transform.LookAt(player);
                }
                break;
        }
        
    }
    private IEnumerator ResumeNavMesh()
    {
        yield return new WaitForSeconds(1.0f); // ジャンプ後に1秒待機
        if (Agent != null)
        {
            Agent.isStopped = false; // NavMeshAgentを再開
            player.gameObject.GetComponent<player_controller>().KB_Flag = false;
        }
    }
    void goto_nextpoint()
    {
        Agent.destination = points[destpoint].position;
        destpoint += 1;
        if (points.Length <= destpoint)
        {
            destpoint = 0;
        }
    }
    public IEnumerator JumpForward()
    {
        if (rb != null)
        {
            while (true)
            {
                if (MITUKETA)
                {

                    Agent.enabled = false;
                    rb.isKinematic = false;
                    while (MITUKETA)
                    {

                        yield return new WaitForSeconds(1.0f);
                        // 前方（プレイヤー方向）にジャンプ
                        Vector3 direction = (player.position - transform.position); // プレイヤー方向の正規化ベクトル
                        direction.y = 0;
                        direction = direction.normalized;
                        direction.y = 0.2f; // 上方向の成分を加える

                        rb.AddForce(direction * speed, ForceMode.Impulse);
                        yield return new WaitForSeconds(1.5f); // ジャンプ後に待機

                    }
                    Agent.enabled = true;
                    rb.isKinematic = true;
                }
                else
                {
                    yield return null;
                }
            }

        }
    }
    public void Playkillsounds()
    {
        audiosource.PlayOneShot(killenemy);
    }
    IEnumerator EnemyKill()
    {
        Isdead = true;
        Playkillsounds();
        yield return new WaitForSeconds(0.15f);

        EG.Enemyspawn();
        score.Plusscore(1);
        Destroy(gameObject);
    }
}
