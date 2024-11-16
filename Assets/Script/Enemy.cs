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
        Agent.SetDestination(player.position);
        // transform.position = new Vector3(transform.position.x+speed, transform.position.y, transform.position.z+speed);
    }
}
