using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[SerializeField]
[CreateAssetMenu(fileName ="Gun_date", menuName ="CreateGun_date")]

public class Gun_detaCreate : ScriptableObject
{
    // Start is called before the first frame update
    public float Shootpower;
    public float ct;
    public int Max_magazine;
    public float relod_time;
    public float taka_time;
    public int Damage;
    public int pellet;
    public float diffusion;
    public GameObject Gun_Object;
    public Transform startpoint;
    public Vector3 MFsize;
    public Animator Gun_animator;
    
    public float GetShootpower()
    {
        return Shootpower;
    }
    public float Getct()
    {
        return ct;
    }
    public float GetMax_magazine()
    {
        return Max_magazine;
    }
    public float Getrelod_time()
    {
        return relod_time;
    }
    public float Gettaka_time()
    {
        return taka_time;
    }
    public float GetDamage()
    {
        return Damage;
    }
    public float Getpellet()
    {
        return pellet;
    }
    public float Getdiffusion()
    {
        return diffusion;
    }
    public GameObject GetGun_Object()
    {
        return Gun_Object;
    }
    public Transform Getstartpoin()
    {
        return startpoint;
    }
    public Vector3 GetMFsize()
    {
        return MFsize;
    }
    public Animator GetGun_animator()
    {
        return Gun_animator;
    }
}
