using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour {

    GameObject gameOverText;

    GameObject scoreText;

    GameObject hpGauge;

    private int sumScore = 0;

	// Use this for initialization
	void Start () {

        hpGauge = GameObject.Find("hpGauge");

        gameOverText = GameObject.Find("GameOverText");

        scoreText = GameObject.Find("ScoreText");

        scoreText.GetComponent<Text>().text = "ScoreText" + sumScore;
    }
	
	// Update is called once per frame
	void Update () {

      

    }

    //public void DecreaseHp(string enemy)
    //{
    //    if (enemy == Skeleton)
    //    {
    //        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    //    }
    //    if(enemy == Boss)
    //    {
    //        this.hpGauge.GetComponent<Image>().fillAmount -= 0.2f;
    //    }
    //}


    public void GameOver()
    {
        //GameOverを表示
        gameOverText.GetComponent<Text>().text = "GemaeOver";
        if (Input.GetMouseButtonDown(0))
        {
            //GameSceneを読み込む（追加
            SceneManager.LoadScene("GameScene");

        }

    }

    public void SumScore(int score)
    {
        sumScore += score;
    }
   

}
