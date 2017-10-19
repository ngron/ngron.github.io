using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    //public GameObject ExploadObj;
    //public GameObject ExploadPos;
    // Use this for initialization
    void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SkeletonTag" || other.gameObject.tag == "BossTag")
        {

            GetComponent<ParticleSystem>().Play();

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }       

    }
}
