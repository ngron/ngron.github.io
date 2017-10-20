using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public int hp = 100;

    public float speed = 30.0f;

    Rigidbody myRigidbody;

    bool tap = false;


    // Use this for initialization
    void Start () {


        myRigidbody = GetComponent<Rigidbody>();

      
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1") && tap)
        {
            //GameSceneを読み込む
            SceneManager.LoadScene("GameScene");

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            myRigidbody.AddForce(transform.forward * speed);
        }
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    myRigidbody.AddForce(0,0,-speed);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
           
        //{
        //    myRigidbody.AddForce(-speed, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    myRigidbody.AddForce(speed, 0, 0);
        //}
    }

    private void OnCollisionStay(Collision other)
    {
        if (hp <= 0)
        {
            //UIControllerからGameOVer関数を呼び出す
            GameObject uiController = GameObject.Find("UIController");

            uiController.GetComponent<UIController>().GameOver();

            tap = true;

        }
        if (other.gameObject.tag == "SkeletonTag")
        {
            hp -= 1;

            GameObject uiController = GameObject.Find("UIController");

            uiController.GetComponent<UIController>().DecreaseHp(0.001f);
        }
        if (other.gameObject.tag == "BossTag")
        {
            hp -= 2;

            GameObject uiController = GameObject.Find("UIController");

            uiController.GetComponent<UIController>().DecreaseHp(0.002f);
        }

        //if (hp == 0)
        //{
        //    //UIControllerからGameOVer関数を呼び出す
        //    GameObject uiController = GameObject.Find("UIController");

        //    uiController.GetComponent<UIController>().GameOver();

        //    tap = true;
            
        //}
    }
}
