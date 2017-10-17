using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public int hp = 100;

    public GameObject ExploadObj;
    public GameObject ExploadPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(hp == 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "BulletTag")
        {
            hp -= 1;
            Instantiate(ExploadObj, ExploadPos.transform.position, Quaternion.identity);

        }
    }
}
