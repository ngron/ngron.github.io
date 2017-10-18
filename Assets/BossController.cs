using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public int hp = 100;

    private bool collision = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (collision == true)
        {
            GetComponent<Animation>().Play("walk");
        }
        if(collision == false)
        {
            GetComponent<Animation>().Play("hit2");
        }

        if (hp == 0)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "BulletTag")
        {
            hp -= 1;
        }

    }

    private void OnCollisionStay(Collision other)
    {

        if (other.gameObject.tag == "PlayerTag")
        {
            collision = false;
 
        }
    }

    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.tag == "PlayerTag")
        {
            collision = true;
        }
    }
}
