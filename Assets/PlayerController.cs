using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody myRigidbody;

    private float speed = 5.0f;

    //public int hp = 10;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update() {

        //if(hp == 0)
        //{
        //    Destroy(gameObject);
        //}

        if (Input.GetKey(KeyCode.UpArrow))
        {
            myRigidbody.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            myRigidbody.AddForce(0,0,-speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
           
        {
            myRigidbody.AddForce(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.AddForce(speed, 0, 0);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "SkeletonTag")
        {
            //hp -= 1;
        }
        if(other.gameObject.tag == "BossTag")
        {
            //hp -= 2;
        }
    }
}
