using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour {

    public Animator anim;
    public int hp = 50;

    public GameObject ExploadObj;
    public GameObject ExploadPos;

    GameObject enemyGenerator;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

       

    }

 
    void OnCollisionEnter(Collision other)
    {
       
        //ボールに当たったらhpが1減る
        if (other.gameObject.tag == "BulletTag")
        {
            hp -= 1;
            //HPが0になったら
            if (hp == 0)
            {
                //UIControllerのメソッドにあるスコアに50を渡してあげる
                GameObject uiController = GameObject.Find("UIController");

                uiController.GetComponent<UIController>().SumScore(50);

                //爆発音が鳴って
                GameObject audioController = GameObject.Find("Explosion");

                audioController.GetComponent<AudioController>().AudioCall();

                //爆発して
                Instantiate(ExploadObj, ExploadPos.transform.position, Quaternion.identity);

                //消える
                Destroy(gameObject);
                //Invoke("DelayMethod", 0.5f);

            }
        }
        
    }

　　//プレイヤーに当たっている間のアニメーションの処理
    private void OnCollisionStay(Collision other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "PlayerTag")
        {
            anim.SetBool("Attack", true);
        }
    }
    //プレイヤーから出てった時のアニメーションの処理
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "PlayerTag")
        {
            anim.SetBool("Attack", false);
        }
    }

    //void DelayMethod()
    //{
    //    Destroy(gameObject);
    //}

}
