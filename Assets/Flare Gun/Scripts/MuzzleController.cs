using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleController : MonoBehaviour
{

    public float time = 0f;

    public float interval = 1f;

    //AudioSouceコンポーネントを取得
    public AudioSource sound;
    //Audioファイルを代入
    public AudioClip shotSound; //発砲音を代入

    // Use this for initialization
    void Start()
    {
        sound = this.gameObject.GetComponent<AudioSource>();    //Audio Sourceコンポーネントを代入
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (time >= interval)
            {
                GetComponent<ParticleSystem>().Play();

                Shoot();
            }
        }
    }
    void Shoot()
    {
        //発射されるときに実行
        sound.PlayOneShot(shotSound);   //この関数は音声がなり終わらないうちにもう一度実行されると、重ねて音が再生される
    }
}