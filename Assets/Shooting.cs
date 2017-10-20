using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;

    public Transform muzzle;

    public float speed = 2000;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //タップしている間
        if (Input.GetButton("Fire1")) {

            //銃弾が複製
            GameObject bullets = GameObject.Instantiate(bullet) as GameObject;

            Vector3 force;
            force = this.gameObject.transform.forward * speed;
            //力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);
            //銃弾の位置を決める
            bullets.transform.position = muzzle.position;

        }
    }
   
    
}
