using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneretor : MonoBehaviour {

    public GameObject plyaer;
    public GameObject Skeleton;
    public GameObject Boss;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //60秒過ぎるまで時間が経過
        for (float time = 0; time <=60; time += Time.deltaTime)
        {
            
            if (time <= 10)
            {
                GameObject skeleton = Instantiate(Skeleton) as GameObject;
                skeleton.transform.position = new Vector3(0, skeleton.transform.position.y, 0);
            }
        }
	}
}
