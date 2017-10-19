using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    Rigidbody myRigidbody;

    private float speed = 30.0f;

    public int hp = 100;
    

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update() {

        if (hp == 0)
        {
            //UIControllerからGameOVer関数を呼び出す
            GameObject uiController = GameObject.Find("UIController");

            uiController.GetComponent<UIController>().GameOver();

        }

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
            hp -= 1;
            
        }
        if (other.gameObject.tag == "BossTag")
        {
            hp -= 2;
        }
    }
}
