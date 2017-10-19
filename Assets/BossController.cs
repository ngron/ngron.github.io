using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public int hp = 100;

    private bool collision = false;

    public GameObject ExploadObj;
    public GameObject ExploadPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //常に歩く
        if (collision == false)
        {
            GetComponent<Animation>().Play("walk");
        }
        //触れている間は攻撃
        if(collision == true)
        {
            GetComponent<Animation>().Play("hit2");
        }
        //hpが0になったら
        if (hp == 0)
        {
            //UIControllerのメソッドにあるスコアに100を渡してあげる
            GameObject uiController = GameObject.Find("UIController");
            uiController.GetComponent<UIController>().SumScore(100);

            //爆発して
            Instantiate(ExploadObj, ExploadPos.transform.position, Quaternion.identity);
            //消える
            Destroy(this.gameObject);

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
            collision = true;
 
        }
    }

    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.tag == "PlayerTag")
        {
            collision = false;
        }
    }
}
