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
        rb = GetComponent<Rigidbody>();
        gun = FindObjectOfType<shooter>();
        Gamemanager = GameObject.FindWithTag("GameController");
        score = Gamemanager.GetComponent<Score>();
        EG = Gamemanager.GetComponent<EnemyGeneraeor>();
        player = GameObject.FindWithTag("player").transform;
        Agent = GetComponent<NavMeshAgent>();
        //Agent.SetDestination(player.position);
        search = transform.GetChild(0).gameObject.GetComponent<search_Script>();
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
        if (search.found_flag == true)
        {
            //Agent.SetDestination(player.position);
            coroutine();
        }
        
        // transform.position = new Vector3(transform.position.x+speed, transform.position.y, transform.position.z+speed);
    }
    // Start is called before the first frame update
  IEnumerator coroutine()
    {
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(Vector3.up);
        yield return new WaitForSeconds(0.5f);
    }
}
