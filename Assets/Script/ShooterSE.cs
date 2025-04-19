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
        if (Time.time - LastGunsound > GunshootSE[num].length|| (num != 0 && num != 2 && num != 3))
        {
            
            audiosource.PlayOneShot(GunshootSE[num]);
            LastGunsound = Time.time;
        }
        
    }
    public IEnumerator stopSE(int num)
    {
        yield return new WaitForSeconds(2);
        if((num != 0 && num != 2 && num != 3))
        {
            audiosource.Stop();
            LastGunsound = 0;
        }
       
    }
}
