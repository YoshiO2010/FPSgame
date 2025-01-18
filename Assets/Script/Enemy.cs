using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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




    [SerializeField]
    float speed;
    GameObject Gamemanager;
    EnemyGeneraeor EG;
    Score score;
    
    NavMeshAgent Agent;
    
    Transform player;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Buliet"))
        {
            HP-=gun.Getgundamage();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("player"))
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
        gun = FindObjectOfType<shooter>();
        Gamemanager = GameObject.FindWithTag("GameController");
        score = Gamemanager.GetComponent<Score>();
        EG = Gamemanager.GetComponent<EnemyGeneraeor>();
        player = GameObject.FindWithTag("player").transform;
        Agent = GetComponent<NavMeshAgent>();
        Agent.SetDestination(player.position);
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
        if(Agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            Agent.SetDestination(player.position);
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
}
