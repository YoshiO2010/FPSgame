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
    Gamemode_mane Level;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
       Level= GameObject.FindWithTag("Game_mane").GetComponent<Gamemode_mane>();
        if (Level != null)
        {
            switch (Level.gamemode)
            {
                case Gamemode.easy:
                    spawn_num = 3;
                    break;
                case Gamemode.normal:
                    spawn_num = 5;
                    break;
                case Gamemode.hard:
                    spawn_num = 7;
                    break;
                default:
                    break;
            }
        }
       
        
        for (int i = 0; i < spawn_num; i++)
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
        GameObject enemy_obj=Instantiate(Enemyprefab[ramdom], spawmpos, Quaternion.identity);
        Enemy enemy_src = enemy_obj.GetComponent<Enemy>();
        switch (Level.gamemode)
        {
            case Gamemode.easy:
                enemy_src.Attack_power = 5;
                break;
            case Gamemode.normal:
                enemy_src.Attack_power = 10;
                break;
            case Gamemode.hard:
                enemy_src.Attack_power = 20;
                break;
            default:
                break;
        }

    }
}
