using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour {

    public Animator anim;
    public int hp = 50;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
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
       

        if (other.gameObject.tag == "BulletTag")
        {
            hp -= 1;

        }
        
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "PlayerTag")
        {
            anim.SetBool("Attack", true);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "PlayerTag")
        {
            anim.SetBool("Attack", false);
        }
    }

}
