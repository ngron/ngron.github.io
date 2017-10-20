using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour {

    GameObject gameOverText;

    GameObject scoreText;

    GameObject hpGauge;

    GameObject timeText;


    private int sumScore = 0;

	// Use this for initialization
	void Start () {

        hpGauge = GameObject.Find("hpGauge");

        gameOverText = GameObject.Find("GameOverText");

        scoreText = GameObject.Find("ScoreText");

        timeText = GameObject.Find("TimeText");
       
    }
	
	// Update is called once per frame
	void Update () {

        scoreText.GetComponent<Text>().text = "Score:" + sumScore;


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

    　　//時間もスコアも全部消す
        Destroy(timeText);

        Destroy(scoreText);
    }

    public void SumScore(int score)
    {
        sumScore += score;
    }
   
    public void DecreaseHp(float damage)
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= damage;
    }
}
