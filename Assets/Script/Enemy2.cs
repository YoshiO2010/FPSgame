using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    public shooter gun;
    [SerializeField]
    int MaxHP = 5;
    [SerializeField]
    int HP;
    [SerializeField]
    public float KBpower;
    [SerializeField]
    float speed;
    GameObject Gamemanager;
    EnemyGeneraeor EG;
    Score score;
    NavMeshAgent Agent;
    Transform player;
    [SerializeField]
    search_Script search;
    Rigidbody rb;
    public Transform[] points;
    int destpoint;
    [SerializeField]
    Transform parent;
    public bool MITUKETA;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Buliet"))
        {
            HP -= gun.Getgundamage();
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        
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
        Debug.Log(parent.childCount);
        points = new Transform[parent.childCount];
        for (int i = 0;i< parent.childCount; i++)
        {
            points[i] = parent.GetChild(i);
        }
        goto_nextpoint();
        StartCoroutine(JumpForward());
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {

            EG.Enemyspawn();
            score.Plusscore(1);
            Destroy(gameObject);

        }
        

        // transform.position = new Vector3(transform.position.x+speed, transform.position.y, transform.position.z+speed);
        if (!Agent.pathPending && Agent.remainingDistance < 0.5f)
        {
            goto_nextpoint();
        }
        if (MITUKETA)
        {
            transform.LookAt(player);
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
                        direction=direction.normalized;
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
    void goto_nextpoint()
    {
        Agent.destination = points[destpoint].position;
        destpoint += 1;
        if (points.Length <= destpoint)
        {
            destpoint = 0;
        }
    }
        
}
