using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSE : MonoBehaviour
{
    [SerializeField]
    AudioSource audiosource;
    [SerializeField]
    AudioClip[] GunshootSE;
    [SerializeField]
    float LastGunsound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySE(int num)
    {
        if (Time.time - LastGunsound > GunshootSE[num].length)
        {
            audiosource.PlayOneShot(GunshootSE[num]);
            LastGunsound = Time.time;
        }
        
    }
    public IEnumerator stopSE()
    {
        yield return new WaitForSeconds(1f);
        audiosource.Stop();
        LastGunsound = 0;
    }
}
