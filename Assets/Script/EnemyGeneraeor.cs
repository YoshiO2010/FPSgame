using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneraeor : MonoBehaviour
{
    [SerializeField]
    float MaxRange;
    [SerializeField]
    float MinRange;
    [SerializeField]
    GameObject[] Enemyprefab;
    Transform player;
    [SerializeField]
    Vector3 MaxLimit;
    [SerializeField]
    Vector3 MinLimit;
    [SerializeField]
    int spawn_num;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
       
        for(int i = 0; i < spawn_num; i++)
        {
            Enemyspawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enemyspawn()
    {
        Vector3 playerpos = player.position;
        float R = Random.Range(MinRange, MaxRange);
        float Rad = Random.value*2*Mathf.PI;
        float x =Mathf.Clamp( R*Mathf.Cos(Rad)+playerpos.x,MinLimit.x,MaxLimit.x);
        float y = 2;
        float z =Mathf.Clamp( R * Mathf.Sin(Rad)+playerpos.z,MinLimit.z,MaxLimit.z);
        Vector3 spawmpos;
        spawmpos = new Vector3(x, y, z);
        int ramdom = Random.Range(0, Enemyprefab.Length);
        Instantiate(Enemyprefab[ramdom], spawmpos, Quaternion.identity);
       
       
    }
}
