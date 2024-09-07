using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public shooter gun;
    [SerializeField]
    int MaxHP = 5;
    [SerializeField]
    int HP;
    [SerializeField]
    GameObject Enemyprefab;
    Vector3 spawmpos;
    [SerializeField]
    Vector3 MaxRange;
    [SerializeField]
    Vector3 MinRange;
    [SerializeField]
    int damage;
    private void OnCollisionEnter(Collision collision)
    {
        damage = gun.Getgundamage();
        if (collision.gameObject.CompareTag("Buliet"))
        {
            HP-=gun.Getgundamage();
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        gun = FindObjectOfType<shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) 
        {
            
            float x = Random.Range(MinRange.x, MaxRange.x);
            float y = Random.Range(MinRange.y, MaxRange.y);
            float z = Random.Range(MinRange.z, MaxRange.z);
            HP = MaxHP;
            spawmpos = new Vector3(x, y, z);
            Instantiate(Enemyprefab, spawmpos, Quaternion.identity);
            Destroy(gameObject);
        } 
    }
}
